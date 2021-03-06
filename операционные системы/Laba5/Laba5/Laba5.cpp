// Laba5.cpp: ���������� ����� ����� ��� ����������.
//

#include "stdafx.h"
#include "windows.h"
#include "resource.h"

/*���������� ������� ����*/
LRESULT  CALLBACK WindowFunc(HWND, UINT, WPARAM, LPARAM);
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
		L"������������ ��� ������ �������",
		WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT, CW_USEDEFAULT,
		CW_USEDEFAULT, CW_USEDEFAULT,
		HWND_DESKTOP, NULL,
		hThisInst, NULL
		);
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
/*----------------------------------------------------*/
HDC memdc;//�������� ���������� ������
HBITMAP hbit;//����� ����������� � ����
HBRUSH hbrush;//���������� ������� �����
HBRUSH hOldbrush;//���������� ������� �����
HPEN hRedpen, hBluepen;//����������� ������
HPEN hOldpen;//���������� �������� ����
int maxX, maxY;//������� ����
/*������� ����� - ���������� ������ �������������*/
POINT mp1[3] = { { 150, 50 }, { 50, 150 }, { 150, 150 } };//1 �����������
POINT mp2[3] = { { 250, 150 }, { 350, 150 }, { 450, 50 } };//2 �����������
COLORREF color = RGB(255, 255, 0);//���� �����
/*---------------------------------------------------------------------
������� ����
-----------------------------------------------------------------------
*/
LRESULT  CALLBACK WindowFunc(HWND hWnd, UINT message, 
	WPARAM wParam, LPARAM lParam){
	HDC hdc;//�������� ���������� ����
	PAINTSTRUCT paintstruct;//�������������� ������� �����������
	switch (message){
	case WM_CREATE:
		/*��������� �������� ����*/
		maxX = GetSystemMetrics(SM_CXSCREEN);
		maxY = GetSystemMetrics(SM_CYSCREEN);
		/*�������� ��������� ���������� ����*/
		hdc = GetDC(hWnd);
		/*�������� ������������ ��������� ���������� ������*/
		memdc = CreateCompatibleDC(hdc);
		/*�������� ������������ ������*/
		hbit = CreateCompatibleBitmap(hdc, maxX, maxY);
		/*����� ���������� ����������� � ��������� ���������� ������*/
		SelectObject(memdc, hbit);
		/*���������� ���� ����� ������*/
		PatBlt(memdc, 0, 0, maxX, maxY, PATCOPY);
		/*�������� �������� � ������ ������*/
		hRedpen = CreatePen(PS_SOLID, 2, RGB(200, 0, 0));
		hBluepen = CreatePen(PS_SOLID, 4, RGB(0, 0, 255));
		/*������������ ��������� ���������� ����*/
		ReleaseDC(hWnd, hdc);
		break;
	case WM_COMMAND://������� ������� ����
		switch (wParam){
		case ID_CLEAR:
			PatBlt(memdc, 0, 0, maxX, maxY, PATCOPY);
			InvalidateRect(hWnd, NULL, 0);
			break;
		case ID_RECT:
			PatBlt(memdc, 0, 0, maxX, maxY, PATCOPY);
			hbrush = CreateSolidBrush(color);
			hOldbrush = (HBRUSH)SelectObject(memdc, hbrush);
			hOldpen = (HPEN)SelectObject(memdc, hRedpen);
			Rectangle(memdc, 50, 50, 200, 200);
			SelectObject(memdc, hBluepen);
			RoundRect(memdc, 250, 50, 400,150,30,300);
			SelectObject(memdc, hOldpen);
			SelectObject(memdc, hOldbrush);
			DeleteObject(hbrush);
			Polygon(memdc, (CONST POINT * )mp1, 3);
			InvalidateRect(hWnd, NULL, 0);
			break;
		case ID_TREUG:
			PatBlt(memdc, 0, 0, maxX, maxY, PATCOPY);
			hbrush = CreateSolidBrush(color);
			hOldbrush = (HBRUSH)SelectObject(memdc, hbrush);
			hOldpen = (HPEN)SelectObject(memdc, hRedpen);
			Polygon(memdc, (CONST POINT *)mp1, 3);
			Polygon(memdc, (CONST POINT *)mp2, 3);
			SelectObject(memdc, hOldpen);
			SelectObject(memdc, hOldbrush);
			DeleteObject(hbrush);
			InvalidateRect(hWnd, NULL, 0);
			break;
		case ID_ELLIPCE:
			PatBlt(memdc, 0, 0, maxX, maxY, PATCOPY);
			hbrush = CreateSolidBrush(color);
			hOldbrush = (HBRUSH)SelectObject(memdc, hbrush);
			hOldpen = (HPEN)SelectObject(memdc, hRedpen);
			Ellipse(memdc, 300, 300, 700, 500);
			Ellipse(memdc, 100, 100, 250, 250);
			SelectObject(memdc, hOldpen);
			SelectObject(memdc, hOldbrush);
			DeleteObject(hbrush);
			InvalidateRect(hWnd, NULL, 0);
			break;
		case ID_RED:
			color = RGB(255, 0, 0);
			break;
		case ID_BLUE:
			color = RGB(0, 0, 255);
			break;
		case ID_BLACK:
			color = RGB(0, 0, 0);
			break;
		}
		break;
	case WM_PAINT://���������� ����
		hdc = BeginPaint(hWnd, &paintstruct);
		BitBlt(hdc, 0, 0, maxX, maxY, memdc, 0, 0,SRCCOPY);
		EndPaint(hWnd, &paintstruct);
		break;
	case WM_DESTROY://"��������� ���������"
		/*�������� ������*/
		DeleteObject(hRedpen);
		DeleteObject(hBluepen);
		DeleteDC(memdc);//�������� ��������� ������
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
}