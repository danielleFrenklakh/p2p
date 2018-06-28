#include "ConnectServer.h"
using namespace std;
#define IP "127.0.0.1"

ConnectServer::ConnectServer(){
	_ListenSocket = INVALID_SOCKET;//initializes the socket
	AcceptSocket = INVALID_SOCKET;
}
int connectClientActivate(){
	return 0;
}
//overrides the p2p virtual function and makes the basic connection between the two peers
int ConnectServer::connectTo()
{
	map<char, int> keyBoardEventMap;//defining the map in order to notice that the keyboard events are printed once

	// Initialize Winsock
	WSADATA wsaData;
	int iResult = 0;//In order to check errors in socket functions

	_ListenSocket = INVALID_SOCKET;
	sockaddr_in serverAddr;

	iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);// initiates use of the Winsock DLL by a process.
	if (iResult != NO_ERROR) {
		wprintf(L"WSAStartup() failed with error: %d\n", iResult);
		return 1;
	}
	_ListenSocket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);	// Create a SOCKET for listening for incoming connection requests.
	if (_ListenSocket == INVALID_SOCKET) {
		wprintf(L"socket function failed with error: %ld\n", WSAGetLastError());
		WSACleanup();
		return 1;
	}
	//----------------------
	// The sockaddr_in structure specifies the address family, IP address, and port for the socket that is being bound.
	serverAddr.sin_family = AF_INET;//can communicate with internet Protocol v4 addresses
	serverAddr.sin_addr.s_addr = INADDR_ANY;//the socket is bound to all local interfaces
	serverAddr.sin_port = htons(PORT);//Initializes to the port defined for the connection

	iResult = bind(_ListenSocket, (SOCKADDR*)& serverAddr, sizeof(serverAddr)); //This function associates a local address with a socket.
	if (iResult == SOCKET_ERROR) {
		wprintf(L"bind function failed with error %d\n", WSAGetLastError());
		iResult = closesocket(_ListenSocket);
		if (iResult == SOCKET_ERROR)
			wprintf(L"closesocket function failed with error %d\n", WSAGetLastError());
		WSACleanup();
		return 1;
	}
	//----------------------
	// Listen for incoming connection requests on the created socket
	if (listen(_ListenSocket, SOMAXCONN) == SOCKET_ERROR)
	{
		wprintf(L"listen function failed with error: %d\n", WSAGetLastError());
		closesocket(_ListenSocket);
		WSACleanup();
		return 1;
	}

	// Create a SOCKET for accepting incoming requests.
	sockaddr_in client;


	wprintf(L"Waiting for client to connect...\n");

	//----------------------
	// Accept the connection.
	int clientSize = sizeof(client);

	AcceptSocket = accept(_ListenSocket, (SOCKADDR*)&client, &clientSize);//accepting incoming requests
	if (AcceptSocket == INVALID_SOCKET)
	{
		wprintf(L"accept failed with error: %ld\n", WSAGetLastError());
		closesocket(_ListenSocket);
		WSACleanup();
		return 1;
	}
	else
	{
		wprintf(L"Client connected.\n");
	}
	//define and get the coordinates of the screen
	int horizontal = 0;
	int vertical = 0;
	int coordinates[2] = {};
	horizontal = getScreenCoordinates()[0];
	vertical = getScreenCoordinates()[1];

	
	char mouseCoord[8];
	long  client_horizontal;
	long  client_vertical;
	

	iResult = recv(AcceptSocket, mouseCoord, 8, 0);//receiving the clients coordinates
	if (iResult == SOCKET_ERROR) {
		printf("recv function failed with error: %d\n", WSAGetLastError());
		closesocket(AcceptSocket);
		WSACleanup();
		return 1;
	}
	else
	{
		/*cout << " mouseCoord[0] " << (int)mouseCoord[0] << "\n";
		cout << " mouseCoord[1] " << (int)mouseCoord[1] << "\n";

		cout << " mouseCoord[2] " << (int)mouseCoord[2] << "\n";
		cout << " mouseCoord[3] " << (int)mouseCoord[3] << "\n";

		cout << " mouseCoord[4] " << (int)mouseCoord[4] << "\n";
		cout << " mouseCoord[5] " << (int)mouseCoord[5] << "\n";
		cout << " mouseCoord[6] " << (int)mouseCoord[6] << "\n";
		cout << " mouseCoord[7] " << (int)mouseCoord[7] << "\n";
		*/
		//printf("string:: %s", mouseCoord);

		//	client_horizontal = (int)mouseCoord[0] + (int)(mouseCoord[1] << 8) + (int)(mouseCoord[2] << 16) + (int)(mouseCoord[3] << 24);
		//setting to hex the coordinates
		client_horizontal = mouseCoord[0] + (mouseCoord[1] >> 8);

		client_vertical = mouseCoord[4] + (mouseCoord[5] << 8) + (mouseCoord[6] << 16) + (mouseCoord[7] << 24);

		//cout << "\n client horizontal\n" << client_horizontal << "\n client vertical\n" << client_vertical;
		//cout << "\n serevr horizontal\n" << horizontal << "\n server vertical\n" << vertical;

	}
	char keyBoard[2];
	char check[2];//if keyboard event or mouse event
	INPUT ip;

	stringstream stream;
	while (true){//loop for receiving events and handeling them
		iResult = recv(AcceptSocket, check, 2, 0);//check if the event is keyboard ot mouse
		if (iResult == SOCKET_ERROR) {
			printf("recv function failed with error: %d\n", WSAGetLastError());
			closesocket(AcceptSocket);
			WSACleanup();
			return 1;
		}
		if (check[0] == '0')//if keyboard case
		{
			iResult = recv(AcceptSocket, keyBoard, 2, 0);//recieve the key pressed in the kyeboard
			if (iResult == SOCKET_ERROR) {
				printf("recv function failed with error: %d\n", WSAGetLastError());
				closesocket(AcceptSocket);
				WSACleanup();
				return 1;
			}
			else
			{

				//printf("\nthis is keyboard event: %d\n", keyBoard[0]);

				if (keyBoardEventMap.count(keyBoard[0]) != 1)//if the key event was not defined yet in the map
				{
					keyBoardEventMap[keyBoard[0]] = 0;//set the letter as a key in the map
				}
				int key_code;//the hex keycode

				stream << (int)keyBoard[0];
				stream >> hex >> key_code;
				//printf("key hex code is: %x \n", key_code);
				//printf("key dec code is: %d \n", key_code);

				// Set up a generic keyboard event.
				ip.type = INPUT_KEYBOARD;
				ip.ki.wScan = 0; // hardware scan code for key
				ip.ki.time = 0;
				ip.ki.dwExtraInfo = 0;

				
				ip.ki.wVk = keyBoard[0]; // put the key event pressed in order to change the event in the computer

				INPUT input[2];
				/*The computer sending the data is sending two characters 
				when one pressed- one for key up and one for key down. we need to print it in our
				computer once and that is why we check if it is the first time or the second
				using the map*/
				if (keyBoardEventMap[keyBoard[0]] == 0)//check if the letter is sent the first time
				{
					ip.ki.dwFlags = 0; // 0 for key press
					// This structure will be used to create the keyboard input event
					ip.ki.dwFlags = 0;
					//cout << "keyBoard[0] " << keyBoard[0];
					if ((keyBoard[0] >= '0' && keyBoard[0] <= '9') || (keyBoard[0] >= 'A' && keyBoard[0] <= 'Z') || (keyBoard[0] >= 'a' && keyBoard[0] <= 'z'))//if letters or numbers
					{
						input[0].type = INPUT_KEYBOARD;//define the event as keyboard event
						input[0].ki.wVk = 0;
						input[0].ki.wScan = keyBoard[0];//the event that was pressed
						input[0].ki.dwFlags = KEYEVENTF_UNICODE;
						input[0].ki.time = 0;
						input[0].ki.dwExtraInfo = GetMessageExtraInfo();
						input[1].type = INPUT_KEYBOARD;
						input[1].ki.wVk = 0;
						input[1].ki.wScan = keyBoard[0];
						input[1].ki.dwFlags = KEYEVENTF_UNICODE | KEYEVENTF_KEYUP;//means the key was pressed and up after pressing
						input[1].ki.time = 0;
						input[1].ki.dwExtraInfo = GetMessageExtraInfo();

						SendInput((UINT)2, input, sizeof(*input));//function that defines the event and changes it in the computer, now its done!
					}
					else//if other chars
					{
						// input event.
						//cout << "different char";
						SendInput(1, &ip, sizeof(INPUT));
					}


					keyBoardEventMap[keyBoard[0]] = 1;//define that the character was printed once
				}
				else
				{
					keyBoardEventMap[keyBoard[0]] = 0;//the character skipped the printing and the next time it should
				}

			}
		}
		else{//mouse event(x,y)
			char bufferX[2];//the x coordinates
			char bufferY[2];//the y coordinates
			char bufferPress[2];//If mouse was pressed
			iResult = recv(AcceptSocket, bufferX, 2, 0);//Receive the x coordinates
			if (iResult == SOCKET_ERROR) {
				printf("recv function failed with error: %d\n", WSAGetLastError());
				closesocket(AcceptSocket);
				WSACleanup();
				return 1;
			}
			iResult = recv(AcceptSocket, bufferY, 2, 0);//Receive the y coordinates
			if (iResult == SOCKET_ERROR) {
				printf("recv function failed with error: %d\n", WSAGetLastError());
				closesocket(AcceptSocket);
				WSACleanup();
				return 1;
			}
			iResult = recv(AcceptSocket, bufferPress, 2, 0);//Receive the press event
			if (iResult == SOCKET_ERROR) {
				printf("recv function failed with error: %d\n", WSAGetLastError());
				closesocket(AcceptSocket);
				WSACleanup();
				return 1;
			}
			//printf
				//("%.3d\t%.3d\t%.3d", bufferX[0], bufferY[0], (int)bufferPress[0]);


			SetCursorPos(bufferX[0] * (horizontal / ((int)mouseCoord[0])), bufferY[0] * (vertical / ((int)mouseCoord[1])));//set the mouse coordinates according to the correct ratio

			if (bufferPress[0] == 001)//if got a click from the computer controlling
			{
				cout << "left click";
				Click(1);
			}
			if (bufferPress[0] == 002)//if got a click from the computer controlling
			{
				cout << "right click";
				Click(2);


			}
			//SetCursorPos(bufferX[0] * (horizontal / ((int)mouseCoord[0])), bufferY[0]);

		}


	}

	iResult = closesocket(_ListenSocket);//closing the socket in the end
	if (iResult == SOCKET_ERROR) {
		wprintf(L"closesocket function failed with error %d\n", WSAGetLastError());
		WSACleanup();
		return 1;
	}
	else
	{
		std::cout << "\nClient disconnected" << std::endl;
	}
	WSACleanup();
	return 0;
}

//the function enables the click events on the mouse
void ConnectServer::Click(int num)
{
	
	INPUT    Input = { 0 };													// Create our input.
	if (num == 1)
	{
		Input.type = INPUT_MOUSE;									// Let input know we are using the mouse.
		Input.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;							// We are setting left mouse button down.
		SendInput(1, &Input, sizeof(INPUT));								// Send the input.

		ZeroMemory(&Input, sizeof(INPUT));									// Fills a block of memory with zeros.
		Input.type = INPUT_MOUSE;									// Let input know we are using the mouse.
		Input.mi.dwFlags = MOUSEEVENTF_LEFTUP;								// We are setting left mouse button up.
		SendInput(1, &Input, sizeof(INPUT));								// Send the input.
	}
	else{
		Input.type = INPUT_MOUSE;									// Let input know we are using the mouse.
		Input.mi.dwFlags = MOUSEEVENTF_RIGHTDOWN;							// We are setting left mouse button down.
		SendInput(1, &Input, sizeof(INPUT));								// Send the input.

		ZeroMemory(&Input, sizeof(INPUT));									// Fills a block of memory with zeros.
		Input.type = INPUT_MOUSE;									// Let input know we are using the mouse.
		Input.mi.dwFlags = MOUSEEVENTF_RIGHTUP;								// We are setting left mouse button up.
		SendInput(1, &Input, sizeof(INPUT));								// Send the input.
	}
	
}


/*
int* ConnectServer::getScreenCoordinates()
{
	int coordinates[2] = {};
	int horizontal = 0;
	int vertical = 0;
	RECT desktop;
	// Get a handle to the desktop window
	const HWND hDesktop = GetDesktopWindow();
	// Get the size of screen to the variable desktop
	GetWindowRect(hDesktop, &desktop);
	// The top left corner will have coordinates (0,0)
	// and the bottom right corner will have coordinates
	// (horizontal, vertical)
	horizontal = desktop.right;
	vertical = desktop.bottom;
	coordinates[0] = horizontal;
	coordinates[1] = vertical;
	return coordinates;

}*/