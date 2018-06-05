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

//register::sss
app.post('/register', function (req, res) {

  var user_data = [req.body.username,req.body.password, req.body.ip_address, false]
  console.log(user_data);
  //console.log(req.body);

  //insert_user(user_data);
  check_credentials_register(req, res, user_data);
  /*if(auth)
  {
    insert_user(user_data);
    res.send("T")
  }
  else{
    res.send("F")
  }*/

})




app.post('/login', function (req, res) {
  console.log(req.body.username);
  var user_data = [req.body.username,req.body.password, req.body.ip_address, false];
//TODO: make a check_credentials function
  check_credentials_login(req, res, user_data);
  /*console.log("auth ", auth)
  if (!auth)
  {
    res.send("F")

  }
  else{
    res.send("T")
  }*/
  /*if(auth){
    console.log("the user can connect!");
  }
  else {
    console.log("bad user");
  }*/


      /*console.log("authentication error " +  auth);
      res.send("authentication error: " + auth);
      is_connected = false;
  }else{
    is_connected = true;
  }*/


})
app.post('/allowConnection', function (req, res) {
	let data = [true, req.body.username];
	let sql = `UPDATE users
				SET is_active = ?
				WHERE username = ?`;
 
	db.run(sql, data, function(err) {
	if (!err) {
		res.send("cool")
	}
	})
})

//connecting to partner
app.post('/connect', function(req, res){
  console.log("got connect POST request");
  var user_data = [req.body.username,req.body.password];
  //get the ip adress from the username
  /*db.each('SELECT ip_address FROM users WHERE username=? AND password=? ',[user_data[0],user_data[1]], (err, row)=>{
    if(err){
      throw err;
    }
    console.log(row.ip_address);*/

    //TODO: send the ip_address to the client
  //ip = return_ip(user_data)

	check_connection_allow(req, res, user_data);
  /*if(user_active(user_data)){
    var ip_address = {"ip":get_ip_from_user(user_credentials)};
    res.send(JSON.stringfy(ip_address));
  }else{
    res.send("user is inactive");
  }*/
	});
app.post('/logout', function (req, res) {
	console.log("disconnect");

	let data = [false, req.body.username];
	let sql = `UPDATE users
				SET is_active = ?
				WHERE username = ?`;
 
	db.run(sql, data, function(err) {
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
app.listen(3000, () => console.log('listening on port 3000!'));



function check_credentials_login(req, res, user_data){
  //check the user login data
  db.get("SELECT * FROM users WHERE username = ? AND password = ?", [user_data[0], user_data[1]],function (err, rows) {
        if (!rows ){
			console.log("No such user");
			res.send("F");
        } 
		else {
			console.log("the username exists, u are allowed to login");
			res.send("T");
        }
    });
}

function check_credentials_register(req, res, user_data){
  //check the user login data
  db.get("SELECT * FROM users WHERE username = ? ",
         [user_data[0]],
         function (err, rows) {
            if (!rows){
              console.log("user does not exist");
			  res.send("T");
			  insert_user(user_data);

            }
            else{
              console.log("user exist");
			  res.send("F");

            }
      });
}
function check_connection_allow(req, res, user_data){
	db.get("SELECT * FROM users WHERE username = ? AND password = ?", [user_data[0], user_data[1]],function (err, rows) {
        if (!rows ){
			console.log("No such user");
			res.send("F");

        } 
		else {
			console.log("the username exists, u are allowed to connect");
			db.each('SELECT ip_address FROM users WHERE username=? AND password=? ',[user_data[0],user_data[1]], (err, row)=>{
			if(err){
				throw err;
			}
			else{
				console.log(row.ip_address);
				res.send(row.ip_address);
			}
		})
        }
	
	
	})
}


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
