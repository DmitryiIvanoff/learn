// Laba5.1.cpp: определяет точку входа для приложения.
//

#include "stdafx.h"
#include "Laba5.1.h"


/*объявление функции окна*/
LRESULT  CALLBACK WindowFunc(HWND, UINT, WPARAM, LPARAM);
HINSTANCE hInstance;//дескриптор приложения
HWND BtWnd, BtWnd2, BtWnd3;//кнопка
HWND EdtWnd, EdtWnd2;//редактор
char szWinName[] = "MyWin";//Имя класса окна
/*---------------------------------------------------------
Главная функция
-----------------------------------------------------------
*/
int WINAPI WinMain(HINSTANCE hThisInst, HINSTANCE hPrevInst, LPSTR lpszArgs, int nWinMode){
	HWND hWnd;//дескриптр окна
	MSG msg;//сообщение
	WNDCLASSEX wcl;//"класс" окна
	/*определение элементов "класса" окна*/
	wcl.hInstance = hThisInst;//дескриптор данного экземпляра
	wcl.lpszClassName = (LPCWSTR)szWinName;//имя "класса" окна
	wcl.lpfnWndProc = WindowFunc;//функция окна
	wcl.style = 0;
	wcl.cbSize = sizeof(WNDCLASSEX);
	wcl.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	wcl.hIconSm = LoadIcon(NULL, IDI_WINLOGO);
	wcl.hCursor = LoadCursor(NULL, IDC_ARROW);
	wcl.lpszMenuName = MAKEINTRESOURCE(IDR_MENU1);//меню
	wcl.cbClsExtra = 0; wcl.cbWndExtra = 0;
	/*Фон окна задается белым*/
	wcl.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
	/*Регистрация класса окна*/
	if (!RegisterClassEx(&wcl))return 0;
	/*Создание окна*/
	hWnd = CreateWindow(
		(LPCWSTR)szWinName,
		L"Menu & Timer & Edit & Button",//заголоовок
		WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT, CW_USEDEFAULT,
		CW_USEDEFAULT, CW_USEDEFAULT,
		HWND_DESKTOP, NULL,
		hThisInst, NULL
		);
	/*Запоминаем дескриптор приложения для создания дочерних
	элементов управления*/
	hInstance = hThisInst;
	/*Отображение окна*/
	ShowWindow(hWnd, nWinMode);
	UpdateWindow(hWnd);
	/*Цикл сообщений*/
	while (GetMessage(&msg, NULL, 0, 0)){
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	return msg.wParam;
}

/*---------------------------------------------------------------------
Функция окна
-----------------------------------------------------------------------
*/
int maxX, maxY,btn3XY=100,X,Y;
LRESULT  CALLBACK WindowFunc(HWND hWnd, UINT message,
	WPARAM wParam, LPARAM lParam){
	char msg[10];
	char msg2[10];
	int r,k;
	switch (message){
	case WM_DESTROY://завершение программы
		PostQuitMessage(0);
		break;
		/*сообщение от пунктов меню и элементов управления*/
	case WM_COMMAND:
		if (LOWORD(wParam) == IDM_START){//пункт  меню старт
			MessageBoxA(hWnd, "Timer 1 started",
				"Generation started", MB_OK);
			SetTimer(hWnd, 1, 1000, NULL);//установка таймера
		}
		if (LOWORD(wParam) == IDM_START2){
			MessageBoxA(hWnd, "Timer 2 started",
				"Generation started", MB_OK);
			SetTimer(hWnd, 2, 2000, NULL);//установка таймера
		}
		if (LOWORD(wParam) == IDM_STOP){//пункт меню стоп
			MessageBoxA(hWnd, "Timer 1 stopped",
				"Generation stopped", MB_OK);
			KillTimer(hWnd, 1);//завершение работы таймера
		}
		if (LOWORD(wParam) == IDM_STOP2){
			MessageBoxA(hWnd, "Timer 2 stopped",
				"Generation stopped", MB_OK);
			KillTimer(hWnd, 2);//завершение работы таймера
		}
		if (HWND(lParam) == BtWnd)//сообщение от консоли
		{
			lstrcpy((LPWSTR)msg, L"0");
			/*помещение текста в поле ввода*/
			SendMessage(EdtWnd, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)msg);
		}
		if (HWND(lParam) == BtWnd2)//сообщение от консоли
		{
			lstrcpy((LPWSTR)msg2, L"0");
			/*помещение текста в поле ввода*/
			SendMessage(EdtWnd2, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)msg2);
		}
		if (HWND(lParam) == BtWnd3){
			/*устанавливаем новое значение edit2+1000*/
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
			/*значение 1 поля -> кол-во времени между срабатыванием таймера*/
			k = SendMessageA(EdtWnd, WM_GETTEXTLENGTH, 0, 0);
			SendMessageA(EdtWnd, WM_GETTEXT, k + 1, (LPARAM)msg);
			SetTimer(hWnd, 3, atoi(msg), NULL);
			/*устанавливаем таймер 4  - значение берем из поля edit2*/
			k = SendMessageA(EdtWnd2, WM_GETTEXTLENGTH, 0, 0);
			SendMessageA(EdtWnd2, WM_GETTEXT, k + 1, (LPARAM)msg2);
			r = atoi(msg2) + 1000;
			SetTimer(hWnd, 4, r, NULL);//продолжительность игры
			break;
		}
		break;
	case WM_TIMER:
		switch (wParam){
		case 1:
			r = rand() % 20;
			/*получение длины текста в поле ввода*/
			k = SendMessageA(EdtWnd, WM_GETTEXTLENGTH, 0, 0);
			/*получение текста из поля воода*/
			SendMessageA(EdtWnd, WM_GETTEXT, k + 1, (LPARAM)msg);
			/*перевод значения из строки в число и суммирование*/
			r += atoi(msg);
			/*перевод из числа в строку*/
			wsprintfA(msg, "%d", r);
			/*помещение текста в поле ввода*/
			SendMessageA(EdtWnd, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)msg);
			break;
		case 2:
			/*получение длины текста в поле ввода 1*/
			k = SendMessageA(EdtWnd, WM_GETTEXTLENGTH, 0, 0);
			/*получение текста из поля воода 1*/
			SendMessageA(EdtWnd, WM_GETTEXT, k + 1, (LPARAM)msg2);
			/*перевод из числа в строку*/
			wsprintfA(msg2, "Timer %d", atoi(msg2));
			/*помещение текста в поле ввода 2*/
			SendMessageA(EdtWnd2, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)msg2);
			break;
		case 3:
			/*удалить и создать кнопку ()*/
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
			/*устанавливаем новое значение edit2-1000*/
			k = SendMessageA(EdtWnd2, WM_GETTEXTLENGTH, 0, 0);
			SendMessageA(EdtWnd2, WM_GETTEXT, k + 1, (LPARAM)msg2);
			r = atoi(msg2) - 1000;
			wsprintfA(msg2, "%d", r);
			SendMessageA(EdtWnd2, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)msg2);
			/*удаляем таймер 4 и создаем по новой с новм значением из Edit2*/
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
	case WM_CREATE://сообщение о создании окна
		/*создание кнопки*/
		//maxX = GetSystemMetrics(SM_CXSCREEN);
		//maxY = GetSystemMetrics(SM_CYSCREEN);
		RECT rect;
		GetClientRect(hWnd, &rect);
		maxX = rect.right;
		maxY = rect.bottom;

		BtWnd = CreateWindow(
			L"BUTTON",//имя класса окна
			L"Reset",//заголовок
			WS_CHILD|WS_VISIBLE|WS_BORDER,//стиль
			5,10,60,40,//координаты и размеры
			hWnd,//дескриптор родительского окна
			NULL,//меню нет
			hInstance,//дескриптор приложения
			NULL
			);
		/*создание редактора(поля ввода)*/
		EdtWnd = CreateWindow(
			L"EDIT",
			L"0",
			WS_CHILD | WS_VISIBLE | WS_BORDER | WS_THICKFRAME,
			70, 10, 70, 40,
			hWnd,
			NULL,
			hInstance,
			NULL);
		/*создание редактора 2 и кнопки 2*/
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