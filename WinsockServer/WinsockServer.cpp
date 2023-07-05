#define _WINSOCK_DEPRECATED_NO_WARNINGS
#define _CRT_SECURE_NO_WARNINGS
#include <iostream> 
#include <cstdio> 
#include <cstring> 
#include <winsock2.h>
#include <list>
#include <string.h>
#pragma comment(lib, "WS2_32.lib")
using namespace std;

int transferMap();

list<SOCKET> clients;

int main()
{
    WSADATA wsaData;
    SOCKET server, client;
    SOCKADDR_IN serverAddr, clientAddr;
    int wsaErr = WSAStartup(MAKEWORD(2, 2), &wsaData);

    if (wsaErr != 0)
    {
        cout << "wsa eror: " << WSAGetLastError() << endl;
        return -1;
    }

    server = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    if (server == INVALID_SOCKET)
    {
        cout << "Socket creation failed with error " << WSAGetLastError() << endl;
        return -1;
    }
    serverAddr.sin_addr.s_addr = inet_addr("192.168.189.17");
    serverAddr.sin_family = AF_INET;
    serverAddr.sin_port = htons(8888);

    if (bind(server, (SOCKADDR*)&serverAddr, sizeof(serverAddr)) == SOCKET_ERROR)
    {
        cout << "Bind func failed " << WSAGetLastError() << endl;
        return -1;
    }

    if (listen(server, 5) == SOCKET_ERROR)
    {
        cout << "error" << endl;
        return -1;
    }

    cout << "Server started" << endl;

    int clientAddrSize = sizeof(clientAddr);
    int i = 0;
    while (clients.size() < 2)
    {
        if (i == 2)
            break;
        if ((client = accept(server, (SOCKADDR*)&clientAddr, &clientAddrSize)) != INVALID_SOCKET)
        {
            cout << "Client " << i << " connected!" << endl;
            clients.push_back(client);
            i++;
        }
    }
    cout << "TransferDataStarted" << endl;
    //DWORD tid;
    //HANDLE t1 = CreateThread(NULL, 0, transferMap, &client, 0, &tid);
    //if (t1 == NULL)
    //    cout << "Thread creation Err: " << WSAGetLastError() << endl;
    int result = transferMap();
    return result;
}

int transferMap()
{
    char mapBuffer[9000] = { 0 };

    SOCKET client1 = clients.front();
    SOCKET client2 = clients.back();

    if (recv(client1, mapBuffer, sizeof(mapBuffer), 0) == SOCKET_ERROR)
    {
        cout << "Recv error client 1" << endl;
        return -1;
    }

    cout << "Client 1 send data: " << mapBuffer << endl;

    if (send(client2, mapBuffer, sizeof(mapBuffer), 0) == SOCKET_ERROR)
    {
        cout << "Send error client 2" << endl;
        return -1;
    }

    if (send(client1, mapBuffer, sizeof(mapBuffer), 0) == SOCKET_ERROR)
    {
        cout << "Send error client 2" << endl;
        return -1;
    }
    char buffer1[2000] = { 0 };
    char buffer2[2000] = { 0 };

    while (true)
    {
        memset(buffer1, 0, sizeof(buffer1));
        memset(buffer2, 0, sizeof(buffer2));

        if (recv(client1, buffer1, sizeof(buffer1), 0) == SOCKET_ERROR)
        {
            cout << "Recv error client 1" << endl;
            return -1;
        }

        cout << "Client 1 send data: " << buffer1 << endl;

        if (send(client2, buffer1, sizeof(buffer1), 0) == SOCKET_ERROR)
        {
            cout << "Send error client 2" << endl;
            return -1;
        }

        if (recv(client2, buffer2, sizeof(buffer2), 0) == SOCKET_ERROR)
        {
            cout << "Recv error client 2" << endl;
        }

        cout << "Client 2 send data: " << buffer2 << endl;

        if (send(client1, buffer2, sizeof(buffer2), 0) == SOCKET_ERROR)
        {
            cout << "Send error client 2" << endl;
            return -1;
        }
    }
    
}