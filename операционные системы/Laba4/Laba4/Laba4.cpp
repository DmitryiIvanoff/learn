// Laba4.cpp: ���������� ����� ����� ��� ����������.
//

#include "stdafx.h"
#include "Laba4.h"

#define MAX_LOADSTRING 100

// ���������� ����������:
HINSTANCE hInst;								// ������� ���������
TCHAR szTitle[MAX_LOADSTRING];					// ����� ������ ���������
TCHAR szWindowClass[MAX_LOADSTRING];			// ��� ������ �������� ����

// ��������� ���������� �������, ���������� � ���� ������ ����:
ATOM				MyRegisterClass(HINSTANCE hInstance);
BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	About(HWND, UINT, WPARAM, LPARAM);

int APIENTRY _tWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPTSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);

 	// TODO: ���������� ��� �����.
	MSG msg;
	HACCEL hAccelTable;

	// ������������� ���������� �����
	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDC_LABA4, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// ��������� ������������� ����������:
	if (!InitInstance (hInstance, SW_MINIMIZE))//������ ����������� ���� - ������ �������� int
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_LABA4));

	// ���� ��������� ���������:
	while (GetMessage(&msg, NULL, 0, 0))
	{
		if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
	}

	return (int) msg.wParam;
}



//
//  �������: MyRegisterClass()
//
//  ����������: ������������ ����� ����.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);

	wcex.style			= CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc	= WndProc;
	wcex.cbClsExtra		= 0;
	wcex.cbWndExtra		= 0;
	wcex.hInstance		= hInstance;
	wcex.hIcon = LoadIcon(hInstance, IDI_HAND);
	wcex.hCursor		= LoadCursor(NULL, IDC_HAND);//��� �������
	wcex.hbrBackground	= (HBRUSH)(2);//���� ����
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDC_LABA4);
	wcex.lpszClassName	= szWindowClass;
	wcex.hIconSm = LoadIcon(wcex.hInstance, IDI_HAND);

	return RegisterClassEx(&wcex);
}

//
//   �������: InitInstance(HINSTANCE, int)
//
//   ����������: ��������� ��������� ���������� � ������� ������� ����.
//
//   �����������:
//
//        � ������ ������� ���������� ���������� ����������� � ���������� ����������, � �����
//        ��������� � ��������� �� ����� ������� ���� ���������.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   HWND hWnd;

   hInst = hInstance; // ��������� ���������� ���������� � ���������� ����������

   hWnd = CreateWindow(szWindowClass, L"������������ ������ 4", WS_OVERLAPPED |WS_MINIMIZEBOX|WS_SYSMENU ,
      10, 10, 800, 800, NULL, NULL, hInstance, NULL);

   if (!hWnd)
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow);//������ ����������� ���� - ������ �������� int
   UpdateWindow(hWnd);

   return TRUE;
}

//
//  �������: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  ����������:  ������������ ��������� � ������� ����.
//
//  WM_COMMAND	- ��������� ���� ����������
//  WM_PAINT	-��������� ������� ����
//  WM_DESTROY	 - ������ ��������� � ������ � ���������.
//
//

int posRbutton, posLbutton, maxX, maxY, previousRbuttonPos, previousLbuttonPos, countRbutton = 0, 
sizeOfRectW = 200, sizeOfRectH = 200, sizoOfEllipceH = 150, sizoOfEllipceW=150, rectDelta=0;
HDC VirtualWindow,memdc;
HBITMAP hBit;
HGDIOBJ black_brush = GetStockObject(BLACK_BRUSH), gray_brush = GetStockObject(DKGRAY_BRUSH),
red_brush = CreateSolidBrush(RGB(255, 0, 0)), blue_brush = CreateSolidBrush(RGB(0, 0, 139));//�����
COLORREF red(RGB(255, 0, 0)), white(RGB(255, 255, 255)), green(RGB(0, 250, 154)), previousTextColor, previousBgColor;
HPEN pen1 = CreatePen(PS_SOLID, 1, red);//�������
HPEN pen2 = CreatePen(PS_DASH, 2, white);//�����
HPEN pen3 = CreatePen(PS_DOT, 3, green);//�������
HBRUSH brush1 = CreateSolidBrush(white);
HBRUSH brush2 = CreateHatchBrush(HS_CROSS, red);
HBRUSH brush3 = CreateSolidBrush(green);
int mode = 1;
BOOL brush_mode = false;
HGDIOBJ hObj1 = black_brush, hObj2 = red_brush;

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	int wmId, wmEvent;
	PAINTSTRUCT ps;
	HDC hdc;
	char msg[40];
	char str[100];
	int xPos, yPos;
	HGDIOBJ PreviousPen,PreviousBrush;
	

	switch (message)
	{
	case WM_KEYDOWN:
		switch (wParam){
		case 0x31:
			mode = 1;
			break;
		case 0x32:
			mode = 2;
			break;
		case 0x33:
			mode = 3;
			break;

		}
		break;
	case WM_CREATE:
		VirtualWindow = GetDC(hWnd);//�������� ��������� ���������� ����
		memdc = CreateCompatibleDC(VirtualWindow);//�������� ������������ ��������� ���������� ������
		RECT rect;
		GetClientRect(hWnd, &rect);
		maxX = rect.right;
		maxY = rect.bottom;
		//maxX = GetSystemMetrics(SM_CXSCREEN);//���������� �������� ��������
		//maxY = GetSystemMetrics(SM_CYSCREEN);//���������� �������� ��������
		hBit = CreateCompatibleBitmap(VirtualWindow, maxX, maxY);//�������� ������������ ������
		SelectObject(memdc, hBit);//����� ������ � �������� ���������� ������
		SelectObject(memdc, black_brush);//����� ������ �����
		PatBlt(memdc, 0, 0, maxX, maxY, PATCOPY);//�������� ���� ������ ������
		ReleaseDC(hWnd, VirtualWindow);//������������ ��������� ���������� ����
		break;
	case WM_RBUTTONDOWN:
		posRbutton = LOWORD(lParam);
		posLbutton = HIWORD(lParam);
		countRbutton++;
		/*
		wsprintfA(str, "%d", countRbutton);
		SetTextColor(memdc, white);
		SetBkColor(memdc, red);
		TextOutA(memdc, posRbutton, posLbutton, str, strlen(str));
		
		SelectObject(memdc, pen3);
		LineTo(memdc, posRbutton, posLbutton);
		MoveToEx(memdc, 0, 0, NULL);
		LineTo(memdc, posRbutton, posLbutton);
		*/
		SelectObject(memdc, black_brush);//����� ������ �����
		PatBlt(memdc, 0, 0, maxX, maxY, PATCOPY);//�������� ���� ������ ������
		/*switch (mode){
		case 2:sizeOfRectH += 5; break;
		case 3:rectDelta-=5; break;
		default:sizeOfRectW -= 10; sizeOfRectH -= 10;
		}*/
		
		InvalidateRect(hWnd, NULL, TRUE);
		break;
	case WM_LBUTTONDOWN:
		xPos = LOWORD(lParam);
		yPos = HIWORD(lParam);
		/*
		if (MessageBoxA(hWnd, "������� ����������?", "����� ������", MB_OKCANCEL | MB_ICONQUESTION) == IDOK){
			wsprintfA(msg, "���������� ������� ����:\nx=%d y=%d", xPos, yPos);
			MessageBoxA(hWnd, msg, "����� ������", MB_OK | MB_ICONINFORMATION);
		};*/
		
		//SelectObject(memdc, black_brush);//����� ������ �����
		SelectObject(memdc, GetStockObject(WHITE_BRUSH));
		PatBlt(memdc, 0, 0, maxX, maxY, PATCOPY);//�������� ���� ����� ������
		
		/*
		switch (mode){
		case 2:sizeOfRectW += 5; break;
		case 3:rectDelta+=5; break;
		default:sizeOfRectW += 10; sizeOfRectH += 10;
		}
		*/

		//black_brush, gray_brush, red_brush , blue_brush
		SelectObject(memdc, pen1);
		if (brush_mode){
			hObj1 = gray_brush, hObj2 = blue_brush;
			brush_mode=false;
		}
		else{
			hObj1 = black_brush, hObj2 = red_brush;
			brush_mode=true;
		}

		SelectObject(memdc, hObj1);
		Rectangle(memdc, xPos, yPos,xPos + sizeOfRectW, yPos + sizeOfRectH);
		SelectObject(memdc, hObj2);
		Ellipse(memdc, xPos, yPos, xPos + sizoOfEllipceW, yPos + sizoOfEllipceH);

		InvalidateRect(hWnd, NULL, TRUE);
		break;
	case WM_COMMAND:
		wmId    = LOWORD(wParam);
		wmEvent = HIWORD(wParam);
		// ��������� ����� � ����:
		switch (wmId)
		{
		case IDM_ABOUT:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
			break;
		case IDM_EXIT:
			DestroyWindow(hWnd);
			break;
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
		break;
	case WM_PAINT:
		
		// TODO: �������� ����� ��� ���������...
		/*PreviousPen = SelectObject(memdc, pen1);
		PreviousBrush = SelectObject(memdc, brush1);
		Rectangle(memdc, 10, 10, maxX / 4, maxY / 4);

		SelectObject(memdc, pen2);
		SelectObject(memdc, brush2);
		Ellipse(memdc, 2 * maxX / 3, 2 * maxY / 3, maxX - 10, maxY - 10);

		SelectObject(memdc, pen1);
		SelectObject(memdc, brush3);
		POINT mT[10];
		mT[0].x = 2 * maxX / 3;
		mT[0].y = maxY/4;
		mT[1].x = 2 * maxX / 3;
		mT[1].y = 10;
		mT[2].x = maxX-10;
		mT[2].y = maxY / 4;
		mT[3].x = maxX - 10;;
		mT[3].y = 10;
		Polygon(memdc, mT, 4);

		SelectObject(memdc, pen3);
		SelectObject(memdc, brush2);
		Ellipse(memdc, 10, maxY - 10, maxX / 4, 2 * maxY / 3);

		wsprintfA(str, "������� ������� ����� ���� x=%d y=%d", posRbutton, posLbutton);
		previousTextColor = SetTextColor(memdc, white);
		previousBgColor = SetBkColor(memdc, red);
		TextOutA(memdc, maxX / 2, maxY / 2, str, strlen(str));*/
		
		/*
		SelectObject(memdc, pen3);
		SelectObject(memdc, GetStockObject(HOLLOW_BRUSH));
		Ellipse(memdc, (maxX / 2) - (sizoOfEllipceW / 2), (maxY / 2) - (sizoOfEllipceH / 2),
			(maxX / 2) + (sizoOfEllipceW / 2), (maxY / 2) + (sizoOfEllipceH / 2));
		SelectObject(memdc, pen2);
		//SelectObject(memdc, CreateSolidBrush(HOLLOW_BRUSH));
		Rectangle(memdc, ((maxX / 2) - rectDelta) - (sizeOfRectW / 2), (maxY / 2) - (sizeOfRectH / 2),
			((maxX / 2) - rectDelta) + (sizeOfRectW / 2), (maxY / 2) + (sizeOfRectH / 2));
		*/

		hdc = BeginPaint(hWnd, &ps);
		BitBlt(hdc, 0, 0, maxX, maxY, memdc, 0, 0, SRCCOPY);

		DeleteDC(hdc);//����������� �������� ���������� ����
		EndPaint(hWnd, &ps);
		break;
	case WM_DESTROY:
		DeleteDC(memdc);//������� ����������� �������� ���������� ������
		DeleteObject(pen1);
		DeleteObject(pen2);
		DeleteObject(pen3);
		DeleteObject(brush1);
		DeleteObject(brush2);
		DeleteObject(brush3);
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

// ���������� ��������� ��� ���� "� ���������".
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{
	case WM_INITDIALOG:
		return (INT_PTR)TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}
		break;
	}
	return (INT_PTR)FALSE;
}
