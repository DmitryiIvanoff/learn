// Laba3.cpp: ���������� ����� ����� ��� ����������� ����������.
//

#include "stdafx.h"
#include <Windows.h>
#include <iostream>

HANDLE hFile, hEvent,hSemaphore,hThread,hMutex;

VOID WINAPI ThreadParent(){
	UINT32 wStatus=WaitForSingleObject(hSemaphore,500);
	LPLONG count=0;
	//ReleaseSemaphore(hSemaphore, 1, count);//����������� �������� �������� �������� ����� �������� �� 1
	char* ch = "����� 1 ������� � �������.\n";
	if (wStatus == WAIT_TIMEOUT){
		ch = "�������� � �������. ����� 1.\n";
	}
	DWORD NumBytes;
	WaitForSingleObject(hMutex, INFINITE);
	if (FALSE == WriteFile(hFile, ch, strlen(ch), &NumBytes, NULL)){
		printf_s("�� ������� �������� ����. ������: %d", GetLastError());
	}
	ReleaseMutex(hMutex);//����������� �������
	printf_s("����� 1 ������� � �������. �������: %d\n", count);
	Sleep(500);
}

int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "russian");
	
	//��������� ������������
	SECURITY_ATTRIBUTES sa;
	sa.nLength = sizeof(sa);
	sa.lpSecurityDescriptor = NULL;
	sa.bInheritHandle = TRUE;
	
	//��������� �� ����
	hFile = CreateFileA("c:\\Users\\username\\Desktop\\�����\\��������� �������\\��\\��� ����\\Laba3\\file.txt", GENERIC_READ|GENERIC_WRITE,
		0, &sa, OPEN_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
	if (hFile == INVALID_HANDLE_VALUE){
		printf_s("�� ������� ������� ����");
		getchar();
		return 1;
	}

	//������� �� �����
	hEvent = CreateEventA(&sa, FALSE, FALSE, "EventTEST");
	if (NULL == hEvent){
		printf_s("�� ������� ������� �����. ������ GetLastError=%08x\n", GetLastError());
		getchar();
		return 1;
	}

	//������� �������
	char hFileName[256];
	wsprintfA(hFileName, "%d %d", hFile, hEvent);
	STARTUPINFOA si = { sizeof(si) };
	PROCESS_INFORMATION pi;
	if (!CreateProcessA("c:\\Users\\username\\Desktop\\�����\\��������� �������\\��\\��� ����\\Laba3\\Debug\\NewProccess.exe",
		hFileName, NULL, NULL, TRUE, CREATE_NEW_CONSOLE, NULL, NULL, &si, &pi)){
		printf_s("�� ������� ������� �������. ������ GetLastError=%08x\n", GetLastError());
		getchar();
		return 1;
	}

	//�� �������
	hSemaphore = CreateSemaphoreA(&sa, 0, 2, "MySemaphore");
	if (NULL == hSemaphore){
		printf_s("�� ������� ������� �������. ������ GetLastError=%08x\n", GetLastError());
		getchar();
		return 1;
	}
	//�� ����� ��� ����� �� �������
	DWORD threadID;
	hThread = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)ThreadParent, NULL, NULL, &threadID);

	//�� �������
	hMutex = CreateMutexA(&sa, FALSE, "MyMutex");
	if (NULL == hMutex){
		printf_s("�� ������� ������� vm.ntrc. ������ GetLastError=%08x\n", GetLastError());
		getchar();
		return 1;
	}
	getchar();
	return 0;
}

