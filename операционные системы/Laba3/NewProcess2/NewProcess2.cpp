// NewProcess2.cpp: ���������� ����� ����� ��� ����������� ����������.
//

#include "stdafx.h"
#include <Windows.h>
#include <iostream>
#define BUFFERSIZE 80

int main(int argc, CHAR* argv[])
{
	setlocale(LC_ALL, "russian");
	DWORD dwRead = 1;
	char buff[BUFFERSIZE];
	int count = 0;
	HANDLE hFile;
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
	
	getchar();
	return 0;
}

