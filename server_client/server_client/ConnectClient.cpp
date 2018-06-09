#pragma comment(lib, "d3d9.lib")

#include "ConnectClient.h"
using namespace std;
ConnectClient::ConnectClient(char* ip)//sets in the constructor the ip address given
{
	_ipAddress = ip;
}
int connectServerActivate(){
	return 0;
}


int ConnectClient::connectTo()
{
	int iResult;//sets the variable to store the errors from the socket functions
	WSADATA WSAData;
	SOCKADDR_IN addr;
	HBITMAP pic = NULL;
	WSAStartup(MAKEWORD(2, 0), &WSAData);
	_server = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);//initialize the socket that connects to the 'server' side

	//initialize and set the data of the socket
	addr.sin_addr.s_addr = inet_addr(_ipAddress);
	addr.sin_family = AF_INET;
	addr.sin_port = htons(PORT);

	if (connect(_server, (SOCKADDR *)&addr, sizeof(addr)) == INVALID_SOCKET)//connect function through the specific port and ip
	{
		wprintf(L"connect function failed with error: %d\n", WSAGetLastError());
		system("PAUSE");
		return 1;
	}
	else{
		std::cout << "Connected to _server!" << std::endl;//checking is the function succeded
	}
		int horizontal = 0;
		int vertical = 0;
		//getting the coordinates of my screen
		horizontal = getScreenCoordinates()[0];
		vertical = getScreenCoordinates()[1];

	

	//	cout << "horizontal" << (int)horizontal;
	//	cout << "vetical" << (int)vertical;


		//it is not possible to send int via socket because the size of int is bigger then char, and that is why we need to convert int to char array
		char mouseCoord_to_send[8];
		mouseCoord_to_send[0] = horizontal & 0xff;
		//cout << "mouseCoord_to_send[0] " << (int)mouseCoord_to_send[0] << "\n";
		mouseCoord_to_send[1] = (horizontal >> 8) & 0xff;
		//cout << "mouseCoord_to_send[1] " << (int)mouseCoord_to_send[1] << "\n";
		mouseCoord_to_send[2] = (horizontal >> 16) & 0xff;
		//cout << "mouseCoord_to_send[2] " << (int)mouseCoord_to_send[2] << "\n";
		mouseCoord_to_send[3] = (horizontal >> 24) & 0xff;
		//cout << "mouseCoord_to_send[3] " << (int)mouseCoord_to_send[3] << "\n";

		mouseCoord_to_send[4] = vertical & 0xff;
		//cout << "mouseCoord_to_send[4] " << (int)mouseCoord_to_send[4] << "\n";
		mouseCoord_to_send[5] = (vertical >> 8) & 0xff;
		//cout << "\nmouseCoord_to_send[5] " << (int)(mouseCoord_to_send[5]) << "\n";
		mouseCoord_to_send[6] = (vertical >> 16) & 0xff;
		//cout << "mouseCoord_to_send[6] " << (int)mouseCoord_to_send[6] << "\n";
		mouseCoord_to_send[7] = (vertical >> 24) & 0xff;
		//cout << "mouseCoord_to_send[7] " << (int)mouseCoord_to_send[7] << "\n";
		//printf("string:: \n%s", mouseCoord_to_send);
		//mouseCoord_to_send = { 1, 2, 3, 4, 5, 6, '7' }

		//iResult = send(_server, mouseCoord_to_send, (int)strlen(mouseCoord_to_send), 0);



		iResult = send(_server, mouseCoord_to_send, (int)strlen(mouseCoord_to_send), 0);//sending the char array with the coordinates to the other computer
		if (iResult == SOCKET_ERROR) {
			cout<<"send failed: %d\n", WSAGetLastError();
			closesocket(_server);
			WSACleanup();
			return 1;
		}

	
	//cout << testBuffer << endl;
	//cout << strlen(testBuffer) << endl;

	
	sendingEventData();
	//coordinations(_server);
	printf("danielle mefageret");
	iResult = closesocket(_server);
	if (iResult == SOCKET_ERROR) {
		wprintf(L"closesocket function failed with error %d\n", WSAGetLastError());
		WSACleanup();
		return 1;
	}
	else
	{
		std::cout << "Client disconnected" << std::endl;
	}
	
	//WSACleanup();
	std::cout << "Socket closed." << std::endl << std::endl;
	system("PAUSE");

	return 0;
}

//This function is capturing the events in this computer and sending them via socket to the other in order to eventually control it
int ConnectClient::sendingEventData()
{
	//cout << "enter function coordinations\n" << endl;
	HANDLE hStdInput, hStdOutput, hEvent;                        
	INPUT_RECORD ir[128];//stores the event tipe and event itselfe                                     
	DWORD nRead;//the number of input records read                                               
	COORD xy;
	UINT i;

	hStdInput = GetStdHandle(STD_INPUT_HANDLE);//A handle to the console input buffer.
	hStdOutput = GetStdHandle(STD_OUTPUT_HANDLE);//A handle to the console output buffer.
	FlushConsoleInputBuffer(hStdInput);//Flushes the console input buffer. All input records currently in the input buffer are discarded.
	hEvent = CreateEvent(NULL, FALSE, FALSE, NULL); /*the function creates an auto-reset event object, the initial state of the event object is nonsignaled,  the event object is created without a name.  the event gets a default security descriptor.*/
	HANDLE handles[2] = { hEvent, hStdInput };

	
	char bf[2] = { '1', '\0'};
	int iResult;
	char checkBuffer[2] = { '1', '\0' };//buffer that his value is 0 if the event is keyboard or 1 for mouse event

	while (WaitForMultipleObjects(2, handles, FALSE, INFINITE))//Waits until one or all of the specified objects are in the signaled state or the time-out interval elapses
	{
		ReadConsoleInput(hStdInput, ir, 128, &nRead);//Reads data from a console input buffer and removes it from the buffer.
		for (i = 0; i < nRead; i++)
		{
			switch (ir[i].EventType)//gets the event type
			{
			case KEY_EVENT:
				checkBuffer[0] = '0';
				iResult = send(_server, checkBuffer, 2, 0);//sends via socket that we are hendeling with key event
				if (iResult == SOCKET_ERROR) {
					cout << "send failed: " << WSAGetLastError();
					closesocket(_server);
					WSACleanup();
					return 1;
				}
				if (ir[i].Event.KeyEvent.wVirtualKeyCode == VK_ESCAPE)
					SetEvent(hEvent);
				else
				{
					xy.X = 0; xy.Y = 0;
					SetConsoleCursorPosition(hStdOutput, xy);//Sets the cursor position in the specified console screen buffer.
					/*
					printf
						(
						"AsciiCode = %d: symbol = %c\n",
						ir[i].Event.KeyEvent.uChar.AsciiChar,
						ir[i].Event.KeyEvent.uChar.AsciiChar
						);
					*/
					bf[0] = ir[i].Event.KeyEvent.uChar.AsciiChar;
					//cout << "\nbf " << bf;
					
					//cout << strlen(bf);
					//printf("sending\n");
					iResult = send(_server, bf, 2, 0);//sending the key event
					if (iResult == SOCKET_ERROR) {
						cout << "send failed: "<< WSAGetLastError();
						closesocket(_server);
						WSACleanup();
						return 1;
					}
				}
				break;
			case MOUSE_EVENT:
				checkBuffer[0] = '1';
				iResult = send(_server, checkBuffer, 2, 0);//sending via socket that we handle mouse event
				if (iResult == SOCKET_ERROR) {
					cout << "send failed: " << WSAGetLastError();
					closesocket(_server);
					WSACleanup();
					return 1;
				}
				xy.X = 0, xy.Y = 1;
				SetConsoleCursorPosition(hStdOutput, xy);//Sets the cursor position in the specified console screen buffer.
				/*printf
					(
					"%.3d\t%.3d\t%.3d",
					ir[i].Event.MouseEvent.dwMousePosition.X,
					ir[i].Event.MouseEvent.dwMousePosition.Y,
					(int)ir[i].Event.MouseEvent.dwButtonState & 0x07   //mask out scroll wheel, which screws up
					);*/
				char bufferX[2] = { '1', '\0' };
				char bufferY[2] = { '1', '\0' };
				char bufferPress[2] = { '1', '\0' };

				int x = ir[i].Event.MouseEvent.dwMousePosition.X;
				bufferX[0] = (char)x;
				iResult = send(_server, bufferX, 2, 0);//sends the X position of the mouse when (x,y) are the coordinates
				if (iResult == SOCKET_ERROR) {
					cout << "send failed: " << WSAGetLastError();
					closesocket(_server);
					WSACleanup();
					return 1;
				}
				int y = ir[i].Event.MouseEvent.dwMousePosition.Y;
				bufferY[0] = (char)y;//sends the Y position of the mouse when (x,y) are the coordinates
				iResult = send(_server, bufferY, 2, 0);
				if (iResult == SOCKET_ERROR) {
					cout << "send failed: " << WSAGetLastError();
					closesocket(_server);
					WSACleanup();
					return 1;
				}
				int press = (int)ir[i].Event.MouseEvent.dwButtonState & 0x07;
				bufferPress[0] = (char)press;
				iResult = send(_server, bufferPress, 2, 0);//sends 1 if left click, 2 if right click, 0 if none
				if (iResult == SOCKET_ERROR) {
					cout << "send failed: " << WSAGetLastError();
					closesocket(_server);
					WSACleanup();
					return 1;
				}
				//char testBuffer[1000] = {  (char)a, (char)b };              //execution will drop out of the while loop
				//and program termination will occur.

				//send(_server, testBuffer, strlen(testBuffer), 0);
				break;

			}
		}
	};

	return 0;
	
}
/* 
int* ConnectClient::getScreenCoordinates()
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