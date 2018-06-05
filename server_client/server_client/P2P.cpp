#include "P2P.h"
P2P::P2P(){
	_ListenSocket = INVALID_SOCKET;
	_server = INVALID_SOCKET;
	_ipAddress = "";
}

P2P::~P2P() {}