// Laba5.1.cpp: ���������� ����� ����� ��� ����������.
//

#include "stdafx.h"
#include "Laba5.1.h"


/*���������� ������� ����*/
LRESULT  CALLBACK WindowFunc(HWND, UINT, WPARAM, LPARAM);
HINSTANCE hInstance;//���������� ����������
HWND BtWnd, BtWnd2, BtWnd3;//������
HWND EdtWnd, EdtWnd2;//��������
char szWinName[] = "MyWin";//��� ������ ����
/*---------------------------------------------------------
������� �������
-----------------------------------------------------------
*/
int WINAPI WinMain(HINSTANCE hThisInst, HINSTANCE hPrevInst, LPSTR lpszArgs, int nWinMode){
	HWND hWnd;//��������� ����
	MSG msg;//���������
	WNDCLASSEX wcl;//"�����" ����
	/*����������� ��������� "������" ����*/
	wcl.hInstance = hThisInst;//���������� ������� ����������
	wcl.lpszClassName = (LPCWSTR)szWinName;//��� "������" ����
	wcl.lpfnWndProc = WindowFunc;//������� ����
	wcl.style = 0;
	wcl.cbSize = sizeof(WNDCLASSEX);
	wcl.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	wcl.hIconSm = LoadIcon(NULL, IDI_WINLOGO);
	wcl.hCursor = LoadCursor(NULL, IDC_ARROW);
	wcl.lpszMenuName = MAKEINTRESOURCE(IDR_MENU1);//����
	wcl.cbClsExtra = 0; wcl.cbWndExtra = 0;
	/*��� ���� �������� �����*/
	wcl.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
	/*����������� ������ ����*/
	if (!RegisterClassEx(&wcl))return 0;
	/*�������� ����*/
	hWnd = CreateWindow(
		(LPCWSTR)szWinName,
		L"Menu & Timer & Edit & Button",//����������
		WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT, CW_USEDEFAULT,
		CW_USEDEFAULT, CW_USEDEFAULT,
		HWND_DESKTOP, NULL,
		hThisInst, NULL
		);
	/*���������� ���������� ���������� ��� �������� ��������
	��������� ����������*/
	hInstance = hThisInst;
	/*����������� ����*/
	ShowWindow(hWnd, nWinMode);
	UpdateWindow(hWnd);
	/*���� ���������*/
	while (GetMessage(&msg, NULL, 0, 0)){
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	return msg.wParam;
}

/*---------------------------------------------------------------------
������� ����
-----------------------------------------------------------------------
*/
int maxX, maxY,btn3XY=100,X,Y;
LRESULT  CALLBACK WindowFunc(HWND hWnd, UINT message,
	WPARAM wParam, LPARAM lParam){
	char msg[10];
	char msg2[10];
	int r,k;
	switch (message){
	case WM_DESTROY://���������� ���������
		PostQuitMessage(0);
		break;
		/*��������� �� ������� ���� � ��������� ����������*/
	case WM_COMMAND:
		if (LOWORD(wParam) == IDM_START){//�����  ���� �����
			MessageBoxA(hWnd, "Timer 1 started",
				"Generation started", MB_OK);
			SetTimer(hWnd, 1, 1000, NULL);//��������� �������
		}
		if (LOWORD(wParam) == IDM_START2){
			MessageBoxA(hWnd, "Timer 2 started",
				"Generation started", MB_OK);
			SetTimer(hWnd, 2, 2000, NULL);//��������� �������
		}
		if (LOWORD(wParam) == IDM_STOP){//����� ���� ����
			MessageBoxA(hWnd, "Timer 1 stopped",
				"Generation stopped", MB_OK);
			KillTimer(hWnd, 1);//���������� ������ �������
		}
		if (LOWORD(wParam) == IDM_STOP2){
			MessageBoxA(hWnd, "Timer 2 stopped",
				"Generation stopped", MB_OK);
			KillTimer(hWnd, 2);//���������� ������ �������
		}
		if (HWND(lParam) == BtWnd)//��������� �� �������
		{
			lstrcpy((LPWSTR)msg, L"0");
			/*��������� ������ � ���� �����*/
			SendMessage(EdtWnd, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)msg);
		}
		if (HWND(lParam) == BtWnd2)//��������� �� �������
		{
			lstrcpy((LPWSTR)msg2, L"0");
			/*��������� ������ � ���� �����*/
			SendMessage(EdtWnd2, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)msg2);
		}
		if (HWND(lParam) == BtWnd3){
			/*������������� ����� �������� edit2+1000*/
			k = SendMessageA(EdtWnd2, WM_GETTEXTLENGTH, 0, 0);
			SendMessageA(EdtWnd2, WM_GETTEXT, k + 1, (LPARAM)msg2);
			r = atoi(msg2) + 1000;
			wsprintfA(msg2, "%d", r);
			SendMessageA(EdtWnd2, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)msg2);
		}
		switch (wParam){
		case ID_EXIT:
			DestroyWindow(hWnd);
			break;
		case IDM_GAME:
			KillTimer(hWnd, 1);
			KillTimer(hWnd, 2);
			KillTimer(hWnd, 3);
			KillTimer(hWnd, 4);
			/*�������� 1 ���� -> ���-�� ������� ����� ������������� �������*/
			k = SendMessageA(EdtWnd, WM_GETTEXTLENGTH, 0, 0);
			SendMessageA(EdtWnd, WM_GETTEXT, k + 1, (LPARAM)msg);
			SetTimer(hWnd, 3, atoi(msg), NULL);
			/*������������� ������ 4  - �������� ����� �� ���� edit2*/
			k = SendMessageA(EdtWnd2, WM_GETTEXTLENGTH, 0, 0);
			SendMessageA(EdtWnd2, WM_GETTEXT, k + 1, (LPARAM)msg2);
			r = atoi(msg2) + 1000;
			SetTimer(hWnd, 4, r, NULL);//����������������� ����
			break;
		}
		break;
	case WM_TIMER:
		switch (wParam){
		case 1:
			r = rand() % 20;
			/*��������� ����� ������ � ���� �����*/
			k = SendMessageA(EdtWnd, WM_GETTEXTLENGTH, 0, 0);
			/*��������� ������ �� ���� �����*/
			SendMessageA(EdtWnd, WM_GETTEXT, k + 1, (LPARAM)msg);
			/*������� �������� �� ������ � ����� � ������������*/
			r += atoi(msg);
			/*������� �� ����� � ������*/
			wsprintfA(msg, "%d", r);
			/*��������� ������ � ���� �����*/
			SendMessageA(EdtWnd, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)msg);
			break;
		case 2:
			/*��������� ����� ������ � ���� ����� 1*/
			k = SendMessageA(EdtWnd, WM_GETTEXTLENGTH, 0, 0);
			/*��������� ������ �� ���� ����� 1*/
			SendMessageA(EdtWnd, WM_GETTEXT, k + 1, (LPARAM)msg2);
			/*������� �� ����� � ������*/
			wsprintfA(msg2, "Timer %d", atoi(msg2));
			/*��������� ������ � ���� ����� 2*/
			SendMessageA(EdtWnd2, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)msg2);
			break;
		case 3:
			/*������� � ������� ������ ()*/
			X = 150 + rand() % (maxX - btn3XY-150);
			Y = 150 + rand() % (maxY - btn3XY-150);
			DestroyWindow(BtWnd3);
			BtWnd3 = CreateWindow(
				L"BUTTON",
				L"Click Me",
				WS_CHILD | WS_VISIBLE | WS_BORDER,
				X, Y, btn3XY, btn3XY,
				hWnd,
				NULL,
				hInstance,
				NULL
				);
			/*������������� ����� �������� edit2-1000*/
			k = SendMessageA(EdtWnd2, WM_GETTEXTLENGTH, 0, 0);
			SendMessageA(EdtWnd2, WM_GETTEXT, k + 1, (LPARAM)msg2);
			r = atoi(msg2) - 1000;
			wsprintfA(msg2, "%d", r);
			SendMessageA(EdtWnd2, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)msg2);
			/*������� ������ 4 � ������� �� ����� � ���� ��������� �� Edit2*/
			k = SendMessageA(EdtWnd2, WM_GETTEXTLENGTH, 0, 0);
			SendMessageA(EdtWnd2, WM_GETTEXT, k + 1, (LPARAM)msg2);
			r = atoi(msg2);
			if (r < 0){
				KillTimer(hWnd, 3);
				KillTimer(hWnd, 4);
				MessageBoxA(hWnd, "End",
					"Game over", MB_OK);
				break;
			}
			KillTimer(hWnd, 4);
			SetTimer(hWnd, 4, r, NULL);
			break;
		case 4:
			KillTimer(hWnd, 1);
			KillTimer(hWnd, 2);
			KillTimer(hWnd, 3);
			KillTimer(hWnd, 4);
			MessageBoxA(hWnd, "End",
				"Game over", MB_OK);
			break;
		}
		break;
	case WM_CREATE://��������� � �������� ����
		/*�������� ������*/
		//maxX = GetSystemMetrics(SM_CXSCREEN);
		//maxY = GetSystemMetrics(SM_CYSCREEN);
		RECT rect;
		GetClientRect(hWnd, &rect);
		maxX = rect.right;
		maxY = rect.bottom;

		BtWnd = CreateWindow(
			L"BUTTON",//��� ������ ����
			L"Reset",//���������
			WS_CHILD|WS_VISIBLE|WS_BORDER,//�����
			5,10,60,40,//���������� � �������
			hWnd,//���������� ������������� ����
			NULL,//���� ���
			hInstance,//���������� ����������
			NULL
			);
		/*�������� ���������(���� �����)*/
		EdtWnd = CreateWindow(
			L"EDIT",
			L"0",
			WS_CHILD | WS_VISIBLE | WS_BORDER | WS_THICKFRAME,
			70, 10, 70, 40,
			hWnd,
			NULL,
			hInstance,
			NULL);
		/*�������� ��������� 2 � ������ 2*/
		BtWnd2 = CreateWindow(
			L"BUTTON",
			L"Reset 2",
			WS_CHILD | WS_VISIBLE | WS_BORDER,
			5, 60, 60, 40,
			hWnd,
			NULL,
			hInstance,
			NULL
			);
		EdtWnd2 = CreateWindow(
			L"EDIT",
			L"0",
			WS_CHILD | WS_VISIBLE | WS_BORDER | WS_THICKFRAME,
			70, 60, 70, 40,
			hWnd,
			NULL,
			hInstance,
			NULL
			);
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}