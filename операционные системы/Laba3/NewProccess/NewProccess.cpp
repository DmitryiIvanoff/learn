// NewProccess.cpp: ���������� ����� ����� ��� ����������� ����������.
//

#include "stdafx.h"
#include <Windows.h>
#include <iostream>
#define BUFFERSIZE 80

HANDLE hFile, hEvent, hThread[4],hSemaphore,hMutex,hProcess;
DWORD ThreadId[4];

void ChildThread1(){
	UINT32 wStatus=WaitForSingleObject(hSemaphore, 500);
	PLONG count = 0;
	//ReleaseSemaphore(hSemaphore, 1, count);
	char* ch = "����� 2 ������� � �������.\n";
	if (wStatus == WAIT_TIMEOUT){
		ch = "�������� � �������. ����� 2.\n";
	}
	DWORD NumBytes;
	WaitForSingleObject(hMutex, INFINITE);
	if (FALSE == WriteFile(hFile, ch, strlen(ch), &NumBytes, NULL)){
		printf_s("�� ������� �������� ����. ������: %d", GetLastError());
	}
	ReleaseMutex(hMutex);
	printf_s("����� 2 ������� � �������. �������: %d\n", count);
	Sleep(500);
}

void ChildThread2(){
	UINT32 wStatus = WaitForSingleObject(hSemaphore, 500);
	PLONG count = 0;
	//ReleaseSemaphore(hSemaphore, 1, count);
	char* ch = "����� 3 ������� � �������.\n";
	if (wStatus == WAIT_TIMEOUT){
		ch = "�������� � �������. ����� 3.\n";
	}
	DWORD NumBytes;
	WaitForSingleObject(hMutex, INFINITE);
	if (FALSE == WriteFile(hFile, ch, strlen(ch), &NumBytes, NULL)){
		printf_s("�� ������� �������� ����. ������: %d", GetLastError());
	}
	ReleaseMutex(hMutex);//����������� �������
	printf_s("����� 3 ������� � �������. �������: %d\n", count);
	Sleep(500);
}

void ChildThread3(){
	UINT32 wStatus = WaitForSingleObject(hSemaphore, 500);
	PLONG count = 0;
	//ReleaseSemaphore(hSemaphore, 1, count);
	char* ch = "����� 4 ������� � �������.\n";
	if (wStatus == WAIT_TIMEOUT){
		ch = "�������� � �������. ����� 4.\n";
	}
	DWORD NumBytes;
	WaitForSingleObject(hMutex, INFINITE);
	if (FALSE == WriteFile(hFile, ch, strlen(ch), &NumBytes, NULL)){
		printf_s("�� ������� �������� ����. ������: %d", GetLastError());
	}
	ReleaseMutex(hMutex);//����������� �������
	printf_s("����� 4 ������� � �������. �������: %d\n", count);
	Sleep(500);
}

BOOL WINAPI WroteToFile(HANDLE h){
	
	WaitForSingleObject(h,INFINITE);
	char* data = "������ ��� ������\n";
	DWORD NumBytes;
	WaitForSingleObject(hMutex, INFINITE);
	if (FALSE == WriteFile(hFile, data, strlen(data), &NumBytes, NULL)){
		printf_s("�� ������� �������� ����. ������: %d", GetLastError());
	}
	else{
		printf_s("\n������ ������: '%s' � ����: %d ������ �������, ��������: %d ��������\n", data, h, NumBytes);
	}
	ReleaseMutex(hMutex);//����������� �������
	CloseHandle(h);
	return 1;
}

int main(int argc, CHAR* argv[])
{
	setlocale(LC_ALL, "russian");
	if (argc > 0){

		DWORD dwRead = 1;
		char buff[BUFFERSIZE];
		int count = 0;
		//����� �� ����, ���������� � ������������ ��������
		hFile = (HANDLE)atoi(argv[0]);
		while (dwRead > 0 && dwRead <= BUFFERSIZE - 1){
			SetFilePointer(hFile, count, NULL, FILE_BEGIN);
			if (FALSE == ReadFile(hFile, buff, BUFFERSIZE - 1, &dwRead, NULL)){
				printf_s("�� ������� �������� ����. GetLastError=%08x\n", GetLastError());
				getchar();
				return 1;
			};
			count += (int)dwRead;
			buff[dwRead] = '\0';
			printf("%s", buff);
		}

		//������ � �� �������, ���������� � ������������ ��������
		hEvent = OpenEventA(EVENT_ALL_ACCESS, TRUE, "EventTEST");
		if (hEvent == NULL){
			printf_s("�� ������� ������� �� �������. ������ GetLastError=%08x\n", GetLastError());
			getchar();
			return 1;
		}
		//������� �� �����
		hThread[0] = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)WroteToFile, hEvent, 0, &ThreadId[0]);
		//Sleep(2000);
		SetEvent(hEvent);//��������� ������� � ��������� ���������
		
		//������ � �� �������, ���������� � ������������ ��������
		hSemaphore = OpenSemaphoreA(SEMAPHORE_ALL_ACCESS, TRUE, "MySemaphore");
		if (hSemaphore == NULL){
			printf_s("�� ������� ������� �� �������. ������ GetLastError=%08x\n", GetLastError());
			getchar();
			return 1;
		}
		//������� 3 �� �����
		 //ChildThread1, ChildThread2, ChildThread3 
		void (*threads[3])() = { ChildThread1, ChildThread2, ChildThread3 };//������ ���������� �� �������
		for (int i = 0; i < 3; i++){
			hThread[i + 1] = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)threads[i], NULL, NULL, &ThreadId[i + 1]);
		}
		ReleaseSemaphore(hSemaphore, 2, NULL);//����������� �������� �������� �������� ����� �������� �� 2 (�������� 2, �.�.)
		//CreateSemaphoreA(&saev, 0, 2, "MySemaphore"); 2==������������ ����� �������� � ��������
		
		//������ � �� �������, ���������� � ������������ ��������
		hMutex = OpenMutexA(MUTEX_ALL_ACCESS, TRUE, "MyMutex");
		if (hMutex == NULL){
			printf_s("�� ������� ������� �� �������. ������ GetLastError=%08x\n", GetLastError());
			getchar();
			return 1;
		}
		//ReleaseMutex(hMutex);

		//�������� �� �������
		puts("�������� ������� ��������");
		char hFileName[256];
		wsprintfA(hFileName, "%d", hFile);
		STARTUPINFOA si = { sizeof(si) };
		PROCESS_INFORMATION pi;
		if (!CreateProcessA("c:\\Users\\username\\Desktop\\�����\\��������� �������\\��\\��� ����\\Laba3\\Debug\\NewProcess2.exe",
			hFileName, NULL, NULL, TRUE, CREATE_NEW_CONSOLE, NULL, NULL, &si, &pi)){
			printf_s("�� ������� ������� �������. ������ GetLastError=%08x\n", GetLastError());
			getchar();
			return 1;
		};
		hProcess = pi.hProcess;
		HANDLE targetHandle;
		//�������� � �� ������� hProcess �� ���� hFile
		if (!DuplicateHandle(GetCurrentProcess(), hFile, pi.hProcess, &targetHandle, GENERIC_READ, FALSE, 0)){
			printf_s("�� ������� �������� �� hFile � �� hProcess. ������ GetLastError=%08x\n", GetLastError());
			getchar();
			return 1;
		};
	}
	else{
		puts("������");
	}

	getchar();
	return 0;
}

