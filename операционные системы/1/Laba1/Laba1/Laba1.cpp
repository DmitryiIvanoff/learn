// Laba1.cpp: ���������� ����� ����� ��� ����������� ����������.
//

#include "stdafx.h"
#include <Windows.h>
#include <iostream>

int main(int argc, CHAR* argv[],char* envp[])
{
	setlocale(LC_ALL, "russian");
	puts("Hello!!!");
	char current_path[MAX_PATH];
	char new_path[MAX_PATH];
	char environment[MAX_PATH];
	//����������
	GetCurrentDirectoryA(MAX_PATH, current_path);
	printf_s("current directory is: %s\n", current_path);
	SetCurrentDirectoryA("..");
	GetCurrentDirectoryA(MAX_PATH, new_path);
	printf_s("current directory is: %s\n", new_path);
	SetCurrentDirectoryA(current_path);
	//���������� ���������
	GetEnvironmentVariableA("PATH", environment, sizeof(environment));
	printf_s("environment variables is: %s\n���������� ��������� �� ������� envp:\n", environment);
	while (*envp != '\0'){
		printf_s("	%s\n", *envp);
		envp++;
	}
	SetEnvironmentVariableA("NEWVAR", "�:\\");
	GetEnvironmentVariableA("NEWVAR", environment, sizeof(environment));
	printf_s("NEW environment variables is: %s\n", environment);
	//
	STARTUPINFOA si= { sizeof(si) };
	PROCESS_INFORMATION pi;
	SECURITY_ATTRIBUTES sa;
	sa.nLength = sizeof(SECURITY_ATTRIBUTES);
	sa.lpSecurityDescriptor  = NULL;   //������ �� ���������
	sa.bInheritHandle  = TRUE;

	char notepad[256];
	CreateProcessA(NULL, "notepad", NULL, &sa, NULL, NULL, NULL, NULL, &si, &pi);
	wsprintfA(notepad, "%d", pi.hProcess);
	SetEnvironmentVariableA("notepadVar", notepad);
	Sleep(2000);
	char* argForChild = "123 456 789 77";
	if (CreateProcessA("c:\\Users\\username\\Desktop\\�����\\��������� �������\\��\\��� ����\\1\\newProject\\Release\\newProject.exe", 
		argForChild, NULL, NULL, TRUE, CREATE_NEW_CONSOLE, NULL, NULL, &si, &pi)){
		DWORD exitCode;
		WaitForSingleObject(pi.hProcess, INFINITE);
		GetExitCodeProcess(pi.hProcess, &exitCode);
		CloseHandle(pi.hThread);
		CloseHandle(pi.hProcess);
		std::cout << "��� ����������: " << exitCode << "\n" << std::endl;
	}
	getchar();
	return 0;
}

