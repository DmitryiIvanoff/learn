// Laba1.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#define DBNTWIN32
#include <stdio.h>
#include <windows.h>
#include <sqlfront.h>
#include <sqldb.h>

int err_handler(PDBPROCESS, INT, INT, INT, LPCSTR, LPCSTR);
int msg_handler(PDBPROCESS, DBINT, INT, INT, LPCSTR, LPCSTR,
	LPCSTR, DBUSMALLINT);
int _tmain(int argc, _TCHAR* argv[])
{
	return 0;
}

