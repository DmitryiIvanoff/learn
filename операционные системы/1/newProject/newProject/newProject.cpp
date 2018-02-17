// newProject.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <Windows.h>
#include <iostream>

int main(int argc, char* argv[])
{
	setlocale(LC_ALL, "russian");
	char ch[MAX_PATH];
	puts("HELLO CHILD!!!");
	GetEnvironmentVariableA("NEWVAR", ch, sizeof(ch));
	puts(ch);
	char notepadHandle[256];
	GetEnvironmentVariableA("notepadVar", notepadHandle, sizeof(notepadHandle));
	LPDWORD ec=0;
	GetExitCodeProcess((HANDLE)notepadHandle,ec);
	printf_s("Код выхода из блокнота: %d\n", ec);
	if (TerminateProcess((HANDLE)atoi(notepadHandle), 0)){
		printf_s("Процесс %s завершен\n", notepadHandle);
	}
	getchar();
	if (argc>0){
		int res = atoi(argv[0]);
		for (int i = 1; i < argc; i++){
			if (res>atoi(argv[i])){
				res = atoi(argv[i]);
			}
		}
		return res;
	}
	else{
		puts("Не переданы значения");
	}
	return 0;
}

