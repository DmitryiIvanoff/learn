// Laba2.cpp: определяет точку входа для консольного приложения.
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
		printf_s("Thread started with params: %s; Строка из загл. букв: %s ;Matches: %\d\n", text.c_str(), str.c_str(),str.length());
		LeaveCriticalSection(&CrS);
		Sleep(500);
	}
	
	return 0;
}

VOID WINAPI ThreadChangeStringFunction(char *string){
	//создаем строку из которой будут браться рандомно символы
	char ch = 'A';
	std::string str;
	while (ch != '\0'){
		str += ch++;
	}
	while (true){
		EnterCriticalSection(&CrS);
		int k = 0;
		while (*string != '\0')//пока значение ячейки не равно символу конца строки
		{
			//генерим рандомное число
			int i = rand()%(str.length()-1)+1;//(str.length()-1) - т.к. последний символ '\0'
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
	puts("Поток 1 приостановлен, нажмите '1' для запуска, '2' для остановки.\n'4' для запуска второго потока, '3' для остановки\n\
'5'-уничтожить поток 1\n'6'- уничтожить 2 поток\n'7'- создать 1 поток\n'8'- создать 2 поток\n'9' - выйти из программы.");
	while (flag){
		if (GetAsyncKeyState('1') & 0x8000)
		{
			ResumeThread(thread);
			std::cout << "Поток 1 запущен" << std::endl;
			while (GetAsyncKeyState('1') & 0x8000){ Sleep(100); }//зацикливаем - ждем пока не будет нажата др. кнопка
		}
		else if (GetAsyncKeyState('2') & 0x8000){
			SuspendThread(thread);
			std::cout << "Поток 1 приостановлен" << std::endl;
			while (GetAsyncKeyState('2') & 0x8000){ Sleep(100); }
		}
		else if (GetAsyncKeyState('3') & 0x8000){
			SuspendThread(threadChangeString);
			std::cout << "Поток 2 приостановлен" << std::endl;
			while (GetAsyncKeyState('3') & 0x8000){ Sleep(100); }
		}
		else if (GetAsyncKeyState('4') & 0x8000){
			ResumeThread(threadChangeString);
			std::cout << "Поток 2 запущен" << std::endl;
			while (GetAsyncKeyState('4') & 0x8000){ Sleep(100); }
		}
		else if (GetAsyncKeyState('5') & 0x8000){
			TerminateThread(thread,0);
			std::cout << "Поток 1 уничтожен" << std::endl;
			while (GetAsyncKeyState('5') & 0x8000){ Sleep(100); }
		}
		else if (GetAsyncKeyState('6') & 0x8000){
			TerminateThread(threadChangeString,0);
			std::cout << "Поток 2 уничтожен" << std::endl;
			while (GetAsyncKeyState('6') & 0x8000){ Sleep(100); }
		}
		else if (GetAsyncKeyState('7') & 0x8000){
			thread = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)ThreadFunction, (LPVOID)data, 0, NULL);
			std::cout << "Поток 1 создан" << std::endl;
			while (GetAsyncKeyState('7') & 0x8000){ Sleep(100); }
		}
		else if (GetAsyncKeyState('8') & 0x8000){
			threadChangeString = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)ThreadChangeStringFunction, (LPVOID)data, 0, NULL);
			std::cout << "Поток 2 создан" << std::endl;
			while (GetAsyncKeyState('8') & 0x8000){ Sleep(100); }
		}
		else if (GetAsyncKeyState('9') & 0x8000){
			flag = false;
		}
	}
	DeleteCriticalSection(&CrS);
	return 0;
}

