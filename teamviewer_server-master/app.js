const express = require('express')
var net = require('net');
const app = express()
var sqlite3 = require('sqlite3').verbose()
var is_connected = false;
let db = new sqlite3.Database('./db/myDB.db', (err) => {
  if (err) {
    return console.error(err.message);
  }
  console.log('Connected to the in-memory SQlite database.');
});

var bodyParser = require('body-parser');
app.use(bodyParser.urlencoded({ extended: true }));

/*app.get('/', function (req, res) {
  console.log(req.params)

  res.send('Hello World!')
})*/

//handles post request to register
app.post('/register', function (req, res) {

  var user_data = [req.body.username,req.body.password, req.body.ip_address, false]//setting the user data to enter if confirmed to db
  console.log(user_data);//not necessary! Only to check if the user is the correct user entering to db
  //console.log(req.body);

  check_credentials_register(req, res, user_data);//sends the user and the details from the request to check the credentials and the ability to register
})
//handles post request to login
app.post('/login', function (req, res) {
  console.log(req.body.username);////not necessary! Only to check if the user is the correct
  var user_data = [req.body.username,req.body.password, req.body.ip_address, false];//setting the user data to check in the db
  check_credentials_login(req, res, user_data);////sends the user and the details from the request to check the credentials and allow or not to the user to sign in

})
app.post('/allowConnection', function (req, res) {
	let data = [true, req.body.username];
	let sql = `UPDATE users
				SET is_active = ?
				WHERE username = ?`;//?`;//set the command to change the is_active field to 1 where the username is the user name sending the request

	db.run(sql, data, function(err) {////runs the command on the db
	if (!err) {
		res.send("cool")
	}
	})
})

//connecting to partner
app.post('/connect', function(req, res){
  var user_data = [req.body.username,req.body.password];//set the user data of the user willing to connect to

	check_connection_allow(req, res, user_data);////sending to function to check if it is possible to connect to the user
	});
app.post('/logout', function (req, res) {
	console.log("disconnect");

	let data = [false, req.body.username];////sets values to the db command
	let sql = `UPDATE users
				SET is_active = ?
				WHERE username = ?`;////sets the db command to change the field is_active to 0, means not allowing to connect to this user

	db.run(sql, data, function(err) {//runs the command on the db
	if (!err) {
		res.send("cool")
	}
	})
})

app.put('/disconnect', function (req, res) {
  console.log("disconnectiong");
  res.send('disconnected');
})
app.put('/user', function (req, res) {
  res.send('Got a PUT request at /user');
})
app.delete('/user', function (req, res) {
  res.send('Got a DELETE request at /user');
})
app.listen(3000, () => console.log('listening on port 3000!'));////sets the port the server is listening on



function check_credentials_login(req, res, user_data){
  //check the user login data
  /*sends the command to the db and checks selects the user with the username and password sent*/
  db.get("SELECT * FROM users WHERE username = ? AND password = ?", [user_data[0], user_data[1]],function (err, rows) {
        if (!rows ){//if no user with this data
			console.log("No such user");
			res.send("F");//sends back to the user’s interface and does not allow the connection
        }
		else {
			console.log("the username exists, u are allowed to login");
			res.send("T");//sends back to the user’s interface and allow the connection
        }
    });
}

function check_credentials_register(req, res, user_data){
  //check the user register data
  db.get("SELECT * FROM users WHERE username = ? ",
         [user_data[0]],
         function (err, rows) {//send the db a command to check if such user exists in it
            if (!rows){//if does not exist-- which is what we want
              console.log("user does not exist");
			  insert_user(user_data);//inserts to the database the user

			  res.send("T");//sending a confirmation to register and log in the system
            }
            else{//if such user exists
              console.log("user exist");
			  res.send("F");//sending the user interface that the registration did not succeed

            }
      });
}
function check_connection_allow(req, res, user_data){/*checks if the user that we get in the request
is active and exists in order to connect to him*/
	db.get("SELECT * FROM users WHERE username = ? AND password = ? AND is_active = ?", [user_data[0], user_data[1],true],function (err, rows){
  /*sends the command to the db to check if such user
   exists and the password matches the username*/
        if (!rows ){
			       console.log("No such user");
			       res.send("F");//sends to the user interface that the connection is failed

        }
		else {
			console.log("the username exists, u are allowed to connect");
			db.each('SELECT ip_address FROM users WHERE username=? AND password=? ',[user_data[0],user_data[1]], (err, row)=>{
      /*sends a command to the db to get the ip suitable to the user*/
			if(err){
				throw err;
			}
			else{
				//console.log(row.ip_address);
				res.send(row.ip_address);//sends to the user interface the ip of the user
			}
		})
        }


	})
}

/*This functions inserts the given user to the
db with all its data: username, password, ip address
and 0(because not active yet)*/
function insert_user(user_data){
  db.run(`INSERT INTO users(username, password, ip_address, is_active) VALUES(?, ?, ?, ?)`, user_data, function(err) {
   if (err) {
     return console.log(err.message);
   }
   console.log("inserted user to db")
   // get the last insert id
   //console.log(`A row has been inserted with rowid ${this.lastID}`);
 });
}
/*function return_ip(user_data){
  db.each('SELECT ip_address FROM users WHERE username=? AND password=? ',[user_data[0],user_data[1]], (err, row)=>{
    if(err){
      throw err;
    }
    console.log(row.ip_address);
    var ip_send = row.ip_address;
  });
  return 0;
}*/
