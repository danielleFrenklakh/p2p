#include "ConnectServer.h"
using namespace std;
#define IP "127.0.0.1"

ConnectServer::ConnectServer(){
}
int connectClientActivate(){
	return 0;
}
int ConnectServer::connectTo()
{
	map<char, int> keyBoardEventMap;

	//----------------------
	// Initialize Winsock
	WSADATA wsaData;
	int iResult = 0;

	_ListenSocket = INVALID_SOCKET;
	sockaddr_in serverAddr;

	iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
	if (iResult != NO_ERROR) {
		wprintf(L"WSAStartup() failed with error: %d\n", iResult);
		return 1;
	}
	//----------------------
	// Create a SOCKET for listening for incoming connection requests.
	_ListenSocket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (_ListenSocket == INVALID_SOCKET) {
		wprintf(L"socket function failed with error: %ld\n", WSAGetLastError());
		WSACleanup();
		return 1;
	}
	//----------------------
	// The sockaddr_in structure specifies the address family,
	// IP address, and port for the socket that is being bound.
	serverAddr.sin_family = AF_INET;
	serverAddr.sin_addr.s_addr = INADDR_ANY;
	serverAddr.sin_port = htons(PORT);

	iResult = bind(_ListenSocket, (SOCKADDR*)& serverAddr, sizeof(serverAddr));
	if (iResult == SOCKET_ERROR) {
		wprintf(L"bind function failed with error %d\n", WSAGetLastError());
		iResult = closesocket(_ListenSocket);
		if (iResult == SOCKET_ERROR)
			wprintf(L"closesocket function failed with error %d\n", WSAGetLastError());
		WSACleanup();
		return 1;
	}
	//----------------------
	// Listen for incoming connection requests 
	// on the created socket
	if (listen(_ListenSocket, SOMAXCONN) == SOCKET_ERROR)
	{
		wprintf(L"listen function failed with error: %d\n", WSAGetLastError());
		closesocket(_ListenSocket);
		WSACleanup();
		return 1;
	}

	// Create a SOCKET for accepting incoming requests.
	SOCKET AcceptSocket;
	sockaddr_in client;


	wprintf(L"Waiting for client to connect...\n");

	//----------------------
	// Accept the connection.
	int clientSize = sizeof(client);

	AcceptSocket = accept(_ListenSocket, (SOCKADDR*)&client, &clientSize);
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

	/*checking the receiving is working first "draft":
	char buffer [1000]= "";
	iResult = recv(AcceptSocket, buffer, 1000, 0);
	if (iResult == SOCKET_ERROR) {
	printf("recv function failed with error: %d\n", WSAGetLastError());
	closesocket(_server);
	WSACleanup();
	return 1;
	}
	else
	{
	printf(buffer,"\n");
	}
	*/
	/*
	cout << "getting here";
	iResult = recv(AcceptSocket, newBuffer, 2, 0);
	if (iResult == SOCKET_ERROR) {
	printf("recv function failed with error: %d\n", WSAGetLastError());
	closesocket(_server);
	WSACleanup();
	return 1;
	}
	else
	{
	printf(newBuffer, "\n");
	}*/

	int horizontal = 0;
	int vertical = 0;
	int coordinates[2] = {};
	horizontal = getScreenCoordinates()[0];
	vertical = getScreenCoordinates()[1];

	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	/*RECT desktop;
	// Get a handle to the desktop window
	const HWND hDesktop = GetDesktopWindow();
	// Get the size of screen to the variable desktop
	GetWindowRect(hDesktop, &desktop);
	// The top left corner will have coordinates (0,0)
	// and the bottom right corner will have coordinates
	// (horizontal, vertical)
	horizontal = desktop.right;
	vertical = desktop.bottom;
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	//SetCursorPos(bufferX[0] , bufferY[0] );*/



	char mouseCoord[8];
	long  client_horizontal;
	long  client_vertical;
	/*iResult = recv(AcceptSocket, mouseCoord, 8, 0);//receiving the clients coordinates
	if (iResult == SOCKET_ERROR) {
	printf("recv function failed with error: %d\n", WSAGetLastError());
	closesocket(_server);
	WSACleanup();
	return 1;
	}
	else
	{
	cout << " mouseCoord[0] " << (int)mouseCoord[0] << "\n";

	}*/
	iResult = recv(AcceptSocket, mouseCoord, 8, 0);//receiving the clients coordinates
	if (iResult == SOCKET_ERROR) {
		printf("recv function failed with error: %d\n", WSAGetLastError());
		closesocket(_server);
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
		printf("string:: %s", mouseCoord);

		//	client_horizontal = (int)mouseCoord[0] + (int)(mouseCoord[1] << 8) + (int)(mouseCoord[2] << 16) + (int)(mouseCoord[3] << 24);
		client_horizontal = mouseCoord[0] + (mouseCoord[1] >> 8);

		client_vertical = mouseCoord[4] + (mouseCoord[5] << 8) + (mouseCoord[6] << 16) + (mouseCoord[7] << 24);

		cout << "\n client horizontal\n" << client_horizontal << "\n client vertical\n" << client_vertical;
		cout << "\n serevr horizontal\n" << horizontal << "\n server vertical\n" << vertical;

	}
	char keyBoard[2];
	char check[2];//if keyboard event or mouse event
	INPUT ip;

	stringstream stream;
	while (true){
		iResult = recv(AcceptSocket, check, 2, 0);
		if (iResult == SOCKET_ERROR) {
			printf("recv function failed with error: %d\n", WSAGetLastError());
			closesocket(_server);
			WSACleanup();
			return 1;
		}
		if (check[0] == '0')//if keyboard case
		{
			iResult = recv(AcceptSocket, keyBoard, 2, 0);
			if (iResult == SOCKET_ERROR) {
				printf("recv function failed with error: %d\n", WSAGetLastError());
				closesocket(_server);
				WSACleanup();
				return 1;
			}
			else
			{

				printf("\nthis is keyboard event: %d\n", keyBoard[0]);



				if (keyBoardEventMap.count(keyBoard[0]) != 1)
				{
					keyBoardEventMap[keyBoard[0]] = 0;
				}
				int key_code;

				stream << (int)keyBoard[0];
				stream >> hex >> key_code;
				printf("key hex code is: %x \n", key_code);
				printf("key dec code is: %d \n", key_code);

				// Set up a generic keyboard event.
				ip.type = INPUT_KEYBOARD;
				ip.ki.wScan = 0; // hardware scan code for key
				ip.ki.time = 0;
				ip.ki.dwExtraInfo = 0;

				// Press the "A" key
				ip.ki.wVk = keyBoard[0]; // virtual-key code for the "a" key

				INPUT input[2];




				if (keyBoardEventMap[keyBoard[0]] == 0)//check if the input is key down
				{
					ip.ki.dwFlags = 0; // 0 for key press
					// This structure will be used to create the keyboard
					// input event.
					ip.ki.dwFlags = 0;
					cout << "keyBoard[0] " << keyBoard[0];
					if ((keyBoard[0] >= '0' && keyBoard[0] <= '9') || (keyBoard[0] >= 'A' && keyBoard[0] <= 'Z') || (keyBoard[0] >= 'a' && keyBoard[0] <= 'z'))//if letters or numbers
					{
						input[0].type = INPUT_KEYBOARD;
						input[0].ki.wVk = 0;
						input[0].ki.wScan = keyBoard[0];
						input[0].ki.dwFlags = KEYEVENTF_UNICODE;
						input[0].ki.time = 0;
						input[0].ki.dwExtraInfo = GetMessageExtraInfo();
						input[1].type = INPUT_KEYBOARD;
						input[1].ki.wVk = 0;
						input[1].ki.wScan = keyBoard[0];
						input[1].ki.dwFlags = KEYEVENTF_UNICODE | KEYEVENTF_KEYUP;
						input[1].ki.time = 0;
						input[1].ki.dwExtraInfo = GetMessageExtraInfo();

						SendInput((UINT)2, input, sizeof(*input));
					}
					else//if other chars
					{
						// input event.
						cout << "different char";
						SendInput(1, &ip, sizeof(INPUT));
					}


					keyBoardEventMap[keyBoard[0]] = 1;
				}
				else
				{
					keyBoardEventMap[keyBoard[0]] = 0;
				}
				/*if (keyBoardEventMap[keyBoard[0]] == 0)//check if the input is key down
				{
				ip.ki.dwFlags = 0; // 0 for key press
				// This structure will be used to create the keyboard
				// input event.
				ip.ki.dwFlags = 0;
				SendInput(1, &ip, sizeof(INPUT));



				keyBoardEventMap[keyBoard[0]] = 1;
				}
				else if (keyBoardEventMap[keyBoard[0]] == 1)
				{
				// Release the "A" key
				ip.ki.dwFlags =   KEYEVENTF_KEYUP; // KEYEVENTF_KEYUP for key release
				SendInput(1, &ip, sizeof(INPUT));
				keyBoardEventMap[keyBoard[0]] = 0;

				}*/


			}
		}
		else{
			char bufferX[2];
			char bufferY[2];
			char bufferPress[2];
			iResult = recv(AcceptSocket, bufferX, 2, 0);
			if (iResult == SOCKET_ERROR) {
				printf("recv function failed with error: %d\n", WSAGetLastError());
				closesocket(_server);
				WSACleanup();
				return 1;
			}
			iResult = recv(AcceptSocket, bufferY, 2, 0);
			if (iResult == SOCKET_ERROR) {
				printf("recv function failed with error: %d\n", WSAGetLastError());
				closesocket(_server);
				WSACleanup();
				return 1;
			}
			iResult = recv(AcceptSocket, bufferPress, 2, 0);
			if (iResult == SOCKET_ERROR) {
				printf("recv function failed with error: %d\n", WSAGetLastError());
				closesocket(_server);
				WSACleanup();
				return 1;
			}
			printf
				("%.3d\t%.3d\t%.3d", bufferX[0], bufferY[0], (int)bufferPress[0]);


			SetCursorPos(bufferX[0] * (horizontal / ((int)mouseCoord[0])), bufferY[0] * (vertical / ((int)mouseCoord[1])));

			if (bufferPress[0] == 001)//if got a click from the computer controlling
			{
				cout << "left click";
				LeftClick();
			}
			if (bufferPress[0] == 002)//if got a click from the computer controlling
			{
				cout << "right click";
				RightClick();


			}
			//SetCursorPos(bufferX[0] * (horizontal / ((int)mouseCoord[0])), bufferY[0]);

		}


	}

	iResult = closesocket(_ListenSocket);
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

//the function enables the left click event on the mouse
void ConnectServer::LeftClick()
{
	INPUT    Input = { 0 };													// Create our input.

	Input.type = INPUT_MOUSE;									// Let input know we are using the mouse.
	Input.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;							// We are setting left mouse button down.
	SendInput(1, &Input, sizeof(INPUT));								// Send the input.

	ZeroMemory(&Input, sizeof(INPUT));									// Fills a block of memory with zeros.
	Input.type = INPUT_MOUSE;									// Let input know we are using the mouse.
	Input.mi.dwFlags = MOUSEEVENTF_LEFTUP;								// We are setting left mouse button up.
	SendInput(1, &Input, sizeof(INPUT));								// Send the input.
}

void ConnectServer::RightClick()
{
	INPUT    Input = { 0 };													// Create our input.

	Input.type = INPUT_MOUSE;									// Let input know we are using the mouse.
	Input.mi.dwFlags = MOUSEEVENTF_RIGHTDOWN;							// We are setting left mouse button down.
	SendInput(1, &Input, sizeof(INPUT));								// Send the input.

	ZeroMemory(&Input, sizeof(INPUT));									// Fills a block of memory with zeros.
	Input.type = INPUT_MOUSE;									// Let input know we are using the mouse.
	Input.mi.dwFlags = MOUSEEVENTF_RIGHTUP;								// We are setting left mouse button up.
	SendInput(1, &Input, sizeof(INPUT));								// Send the input.
}

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

}