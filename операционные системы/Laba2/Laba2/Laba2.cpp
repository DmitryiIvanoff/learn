// Laba2.cpp: ���������� ����� ����� ��� ����������� ����������.
//

#include "stdafx.h"
#include <Windows.h>
#include <iostream>
#include <regex>

CRITICAL_SECTION CrS;

INT WINAPI ThreadFunction(char* params){
	std::regex rx("[^A-Z]");
	std::string str;
	while (true){
		EnterCriticalSection(&CrS);
		std::string text = params;
		str = std::regex_replace(text, rx, "");
		printf_s("Thread started with params: %s; ������ �� ����. ����: %s ;Matches: %\d\n", text.c_str(), str.c_str(),str.length());
		LeaveCriticalSection(&CrS);
		Sleep(500);
	}
	
	return 0;
}

VOID WINAPI ThreadChangeStringFunction(char *string){
	//������� ������ �� ������� ����� ������� �������� �������
	char ch = 'A';
	std::string str;
	while (ch != '\0'){
		str += ch++;
	}
	while (true){
		EnterCriticalSection(&CrS);
		int k = 0;
		while (*string != '\0')//���� �������� ������ �� ����� ������� ����� ������
		{
			//������� ��������� �����
			int i = rand()%(str.length()-1)+1;//(str.length()-1) - �.�. ��������� ������ '\0'
			*string = str[i];
			k++;
			string++;
		}
		string -= k;
		//std::cout << string << std::endl;
		LeaveCriticalSection(&CrS);
		Sleep(300);
	}
}

int _tmain(int argc, _TCHAR* argv[])
{
	InitializeCriticalSection(&CrS);
	setlocale(LC_ALL, "russian");
	char data[] = { "AbCdFeGh" };
	HANDLE thread,threadChangeString;
	thread = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)ThreadFunction, (LPVOID)data, CREATE_SUSPENDED, NULL);
	threadChangeString = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)ThreadChangeStringFunction, (LPVOID)data, 0, NULL);
	bool flag = true;
	puts("����� 1 �������������, ������� '1' ��� �������, '2' ��� ���������.\n'4' ��� ������� ������� ������, '3' ��� ���������\n\
'5'-���������� ����� 1\n'6'- ���������� 2 �����\n'7'- ������� 1 �����\n'8'- ������� 2 �����\n'9' - ����� �� ���������.");
	while (flag){
		if (GetAsyncKeyState('1') & 0x8000)
		{
			ResumeThread(thread);
			std::cout << "����� 1 �������" << std::endl;
			while (GetAsyncKeyState('1') & 0x8000){ Sleep(100); }//����������� - ���� ���� �� ����� ������ ��. ������
		}
		else if (GetAsyncKeyState('2') & 0x8000){
			SuspendThread(thread);
			std::cout << "����� 1 �������������" << std::endl;
			while (GetAsyncKeyState('2') & 0x8000){ Sleep(100); }
		}
		else if (GetAsyncKeyState('3') & 0x8000){
			SuspendThread(threadChangeString);
			std::cout << "����� 2 �������������" << std::endl;
			while (GetAsyncKeyState('3') & 0x8000){ Sleep(100); }
		}
		else if (GetAsyncKeyState('4') & 0x8000){
			ResumeThread(threadChangeString);
			std::cout << "����� 2 �������" << std::endl;
			while (GetAsyncKeyState('4') & 0x8000){ Sleep(100); }
		}
		else if (GetAsyncKeyState('5') & 0x8000){
			TerminateThread(thread,0);
			std::cout << "����� 1 ���������" << std::endl;
			while (GetAsyncKeyState('5') & 0x8000){ Sleep(100); }
		}
		else if (GetAsyncKeyState('6') & 0x8000){
			TerminateThread(threadChangeString,0);
			std::cout << "����� 2 ���������" << std::endl;
			while (GetAsyncKeyState('6') & 0x8000){ Sleep(100); }
		}
		else if (GetAsyncKeyState('7') & 0x8000){
			thread = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)ThreadFunction, (LPVOID)data, 0, NULL);
			std::cout << "����� 1 ������" << std::endl;
			while (GetAsyncKeyState('7') & 0x8000){ Sleep(100); }
		}
		else if (GetAsyncKeyState('8') & 0x8000){
			threadChangeString = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)ThreadChangeStringFunction, (LPVOID)data, 0, NULL);
			std::cout << "����� 2 ������" << std::endl;
			while (GetAsyncKeyState('8') & 0x8000){ Sleep(100); }
		}
		else if (GetAsyncKeyState('9') & 0x8000){
			flag = false;
		}
	}
	DeleteCriticalSection(&CrS);
	return 0;
}

