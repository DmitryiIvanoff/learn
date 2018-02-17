// NewProccess.cpp: определяет точку входа для консольного приложения.
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
	char* ch = "Поток 2 допущен к ресурсу.\n";
	if (wStatus == WAIT_TIMEOUT){
		ch = "Отказано в доступе. Поток 2.\n";
	}
	DWORD NumBytes;
	WaitForSingleObject(hMutex, INFINITE);
	if (FALSE == WriteFile(hFile, ch, strlen(ch), &NumBytes, NULL)){
		printf_s("Не удалось записать файл. Ошибка: %d", GetLastError());
	}
	ReleaseMutex(hMutex);
	printf_s("Поток 2 допущен к ресурсу. Счетчик: %d\n", count);
	Sleep(500);
}

void ChildThread2(){
	UINT32 wStatus = WaitForSingleObject(hSemaphore, 500);
	PLONG count = 0;
	//ReleaseSemaphore(hSemaphore, 1, count);
	char* ch = "Поток 3 допущен к ресурсу.\n";
	if (wStatus == WAIT_TIMEOUT){
		ch = "Отказано в доступе. Поток 3.\n";
	}
	DWORD NumBytes;
	WaitForSingleObject(hMutex, INFINITE);
	if (FALSE == WriteFile(hFile, ch, strlen(ch), &NumBytes, NULL)){
		printf_s("Не удалось записать файл. Ошибка: %d", GetLastError());
	}
	ReleaseMutex(hMutex);//освобождаем мьютекс
	printf_s("Поток 3 допущен к ресурсу. Счетчик: %d\n", count);
	Sleep(500);
}

void ChildThread3(){
	UINT32 wStatus = WaitForSingleObject(hSemaphore, 500);
	PLONG count = 0;
	//ReleaseSemaphore(hSemaphore, 1, count);
	char* ch = "Поток 4 допущен к ресурсу.\n";
	if (wStatus == WAIT_TIMEOUT){
		ch = "Отказано в доступе. Поток 4.\n";
	}
	DWORD NumBytes;
	WaitForSingleObject(hMutex, INFINITE);
	if (FALSE == WriteFile(hFile, ch, strlen(ch), &NumBytes, NULL)){
		printf_s("Не удалось записать файл. Ошибка: %d", GetLastError());
	}
	ReleaseMutex(hMutex);//освобождаем мьютекс
	printf_s("Поток 4 допущен к ресурсу. Счетчик: %d\n", count);
	Sleep(500);
}

BOOL WINAPI WroteToFile(HANDLE h){
	
	WaitForSingleObject(h,INFINITE);
	char* data = "Строка для записи\n";
	DWORD NumBytes;
	WaitForSingleObject(hMutex, INFINITE);
	if (FALSE == WriteFile(hFile, data, strlen(data), &NumBytes, NULL)){
		printf_s("Не удалось записать файл. Ошибка: %d", GetLastError());
	}
	else{
		printf_s("\nЗапись строки: '%s' в файл: %d прошла успешно, записано: %d символов\n", data, h, NumBytes);
	}
	ReleaseMutex(hMutex);//освобождаем мьютекс
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
		//чтене ОЯ файл, созданного в родительском процессе
		hFile = (HANDLE)atoi(argv[0]);
		while (dwRead > 0 && dwRead <= BUFFERSIZE - 1){
			SetFilePointer(hFile, count, NULL, FILE_BEGIN);
			if (FALSE == ReadFile(hFile, buff, BUFFERSIZE - 1, &dwRead, NULL)){
				printf_s("Не удалось прочесть файл. GetLastError=%08x\n", GetLastError());
				getchar();
				return 1;
			};
			count += (int)dwRead;
			buff[dwRead] = '\0';
			printf("%s", buff);
		}

		//доступ к ОЯ событие, созданного в родительском процессе
		hEvent = OpenEventA(EVENT_ALL_ACCESS, TRUE, "EventTEST");
		if (hEvent == NULL){
			printf_s("Не удалось открыть ОЯ событие. Ошибка GetLastError=%08x\n", GetLastError());
			getchar();
			return 1;
		}
		//создаем ОЯ поток
		hThread[0] = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)WroteToFile, hEvent, 0, &ThreadId[0]);
		//Sleep(2000);
		SetEvent(hEvent);//установка события в свободное состояние
		
		//доступ к ОЯ семафор, созданного в родительском процессе
		hSemaphore = OpenSemaphoreA(SEMAPHORE_ALL_ACCESS, TRUE, "MySemaphore");
		if (hSemaphore == NULL){
			printf_s("Не удалось открыть ОЯ семафор. Ошибка GetLastError=%08x\n", GetLastError());
			getchar();
			return 1;
		}
		//создаем 3 ОЯ поток
		 //ChildThread1, ChildThread2, ChildThread3 
		void (*threads[3])() = { ChildThread1, ChildThread2, ChildThread3 };//массив указателей на функции
		for (int i = 0; i < 3; i++){
			hThread[i + 1] = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)threads[i], NULL, NULL, &ThreadId[i + 1]);
		}
		ReleaseSemaphore(hSemaphore, 2, NULL);//увеличиваем значение счетчика текущего числа ресурсов на 2 (максимум 2, т.к.)
		//CreateSemaphoreA(&saev, 0, 2, "MySemaphore"); 2==максимальное число счетчика в симафоре
		
		//доступ к ОЯ мьютекс, созданного в родительском процессе
		hMutex = OpenMutexA(MUTEX_ALL_ACCESS, TRUE, "MyMutex");
		if (hMutex == NULL){
			printf_s("Не удалось открыть ОЯ мьютекс. Ошибка GetLastError=%08x\n", GetLastError());
			getchar();
			return 1;
		}
		//ReleaseMutex(hMutex);

		//создание ОЯ процесс
		puts("Создание второго процесса");
		char hFileName[256];
		wsprintfA(hFileName, "%d", hFile);
		STARTUPINFOA si = { sizeof(si) };
		PROCESS_INFORMATION pi;
		if (!CreateProcessA("c:\\Users\\username\\Desktop\\учеба\\Четвертый семестр\\ОС\\мои лабы\\Laba3\\Debug\\NewProcess2.exe",
			hFileName, NULL, NULL, TRUE, CREATE_NEW_CONSOLE, NULL, NULL, &si, &pi)){
			printf_s("Не удалось создать процесс. Ошибка GetLastError=%08x\n", GetLastError());
			getchar();
			return 1;
		};
		hProcess = pi.hProcess;
		HANDLE targetHandle;
		//передача в ОЯ процесс hProcess ОЯ файл hFile
		if (!DuplicateHandle(GetCurrentProcess(), hFile, pi.hProcess, &targetHandle, GENERIC_READ, FALSE, 0)){
			printf_s("Не удалось передать ОЯ hFile в ОЯ hProcess. Ошибка GetLastError=%08x\n", GetLastError());
			getchar();
			return 1;
		};
	}
	else{
		puts("Ошибка");
	}

	getchar();
	return 0;
}

