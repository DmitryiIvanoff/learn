// Laba3.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <Windows.h>
#include <iostream>

HANDLE hFile, hEvent,hSemaphore,hThread,hMutex;

VOID WINAPI ThreadParent(){
	UINT32 wStatus=WaitForSingleObject(hSemaphore,500);
	LPLONG count=0;
	//ReleaseSemaphore(hSemaphore, 1, count);//увеличиваем значение счетчика текущего числа ресурсов на 1
	char* ch = "Поток 1 допущен к ресурсу.\n";
	if (wStatus == WAIT_TIMEOUT){
		ch = "Отказано в доступе. Поток 1.\n";
	}
	DWORD NumBytes;
	WaitForSingleObject(hMutex, INFINITE);
	if (FALSE == WriteFile(hFile, ch, strlen(ch), &NumBytes, NULL)){
		printf_s("Не удалось записать файл. Ошибка: %d", GetLastError());
	}
	ReleaseMutex(hMutex);//освобождаем мьютекс
	printf_s("Поток 1 допущен к ресурсу. Счетчик: %d\n", count);
	Sleep(500);
}

int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "russian");
	
	//параметры безопасности
	SECURITY_ATTRIBUTES sa;
	sa.nLength = sizeof(sa);
	sa.lpSecurityDescriptor = NULL;
	sa.bInheritHandle = TRUE;
	
	//открываем ОЯ файл
	hFile = CreateFileA("c:\\Users\\username\\Desktop\\учеба\\Четвертый семестр\\ОС\\мои лабы\\Laba3\\file.txt", GENERIC_READ|GENERIC_WRITE,
		0, &sa, OPEN_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
	if (hFile == INVALID_HANDLE_VALUE){
		printf_s("Не удалось открыть файл");
		getchar();
		return 1;
	}

	//создаем ОЯ ивент
	hEvent = CreateEventA(&sa, FALSE, FALSE, "EventTEST");
	if (NULL == hEvent){
		printf_s("Не удалось создать ивент. Ошибка GetLastError=%08x\n", GetLastError());
		getchar();
		return 1;
	}

	//создаем процесс
	char hFileName[256];
	wsprintfA(hFileName, "%d %d", hFile, hEvent);
	STARTUPINFOA si = { sizeof(si) };
	PROCESS_INFORMATION pi;
	if (!CreateProcessA("c:\\Users\\username\\Desktop\\учеба\\Четвертый семестр\\ОС\\мои лабы\\Laba3\\Debug\\NewProccess.exe",
		hFileName, NULL, NULL, TRUE, CREATE_NEW_CONSOLE, NULL, NULL, &si, &pi)){
		printf_s("Не удалось создать процесс. Ошибка GetLastError=%08x\n", GetLastError());
		getchar();
		return 1;
	}

	//ОЯ семафор
	hSemaphore = CreateSemaphoreA(&sa, 0, 2, "MySemaphore");
	if (NULL == hSemaphore){
		printf_s("Не удалось создать семафор. Ошибка GetLastError=%08x\n", GetLastError());
		getchar();
		return 1;
	}
	//ОЯ поток для теста ОЯ семафор
	DWORD threadID;
	hThread = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)ThreadParent, NULL, NULL, &threadID);

	//ОЯ мьютекс
	hMutex = CreateMutexA(&sa, FALSE, "MyMutex");
	if (NULL == hMutex){
		printf_s("Не удалось создать vm.ntrc. Ошибка GetLastError=%08x\n", GetLastError());
		getchar();
		return 1;
	}
	getchar();
	return 0;
}

