
// OpenGLView.cpp : реализация класса COpenGLView
//

#include "stdafx.h"
// SHARED_HANDLERS можно определить в обработчиках фильтров просмотра реализации проекта ATL, эскизов
// и поиска; позволяет совместно использовать код документа в данным проекте.
#ifndef SHARED_HANDLERS
#include "OpenGL.h"
#endif

#include "OpenGLDoc.h"
#include "OpenGLView.h"
#include "ТFigure.h"
#include "Circle.h"
#include "Line.h"
#include "Ellipsoid.h"
#include "Quadrangle.h"
#include "Rhombus.h"
#include <iostream>
#include <vector>
#include <algorithm>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif
HWND hWnd;
HGLRC hGLRC;

std::vector<ТFigure*> Figures;
// COpenGLView

IMPLEMENT_DYNCREATE(COpenGLView, CView)

BEGIN_MESSAGE_MAP(COpenGLView, CView)
	ON_WM_CREATE()
	ON_WM_DESTROY()
	ON_WM_SIZE()
	ON_WM_KEYDOWN()//обработка сообщений клавиатуры
	ON_COMMAND(CreateMassive, &COpenGLView::OnCreatemassive)
	ON_COMMAND(ShowMassive, &COpenGLView::OnShowmassive)
	ON_COMMAND(ClearMassive, &COpenGLView::OnClearmassive)
	ON_COMMAND(DestroyMassive, &COpenGLView::OnDestroymassive)
	ON_COMMAND(Rotation, &COpenGLView::OnRotation)
	ON_COMMAND(ChangeRadius, &COpenGLView::OnChangeradius)
	ON_COMMAND(MoveRing, &COpenGLView::OnMovering)
	ON_COMMAND(MoveLine, &COpenGLView::OnMoveline)
	ON_COMMAND(MoveRomb, &COpenGLView::OnMoveromb)
	ON_COMMAND(MoveSquare, &COpenGLView::OnMovesquare)
	ON_COMMAND(MoveEllips, &COpenGLView::OnMoveellips)
END_MESSAGE_MAP()

COpenGLView::COpenGLView(){}
COpenGLView::~COpenGLView(){}


void COpenGLView::OnMovering()
{
	//37 - left; 38 -up;39- right;40-down
	int flag = 37 + rand() / (RAND_MAX / 3);
	for (int i = 0; i < Figures.size(); i++){
		if (dynamic_cast<Circle *>(Figures[i])){
			Figures[i]->MoveTo(flag);
		}
	}COpenGLView::OnShowmassive();
}


void COpenGLView::OnMoveline()
{
	//37 - left; 38 -up;39- right;40-down
	int flag = 37 + rand() / (RAND_MAX / 3);
	for (int i = 0; i < Figures.size(); i++){
		if (dynamic_cast<Line *>(Figures[i])){
			Figures[i]->MoveTo(flag);
		}
	}COpenGLView::OnShowmassive();
}


void COpenGLView::OnMoveromb()
{
	//37 - left; 38 -up;39- right;40-down
	int flag = 37 + rand() / (RAND_MAX / 3);
	for (int i = 0; i < Figures.size(); i++){
		if (dynamic_cast<Rhombus *>(Figures[i])){
			Figures[i]->MoveTo(flag);
		}
	}COpenGLView::OnShowmassive();
}


void COpenGLView::OnMovesquare()
{
	//37 - left; 38 -up;39- right;40-down
	int flag = 37 + rand() / (RAND_MAX / 3);
	for (int i = 0; i < Figures.size(); i++){
		if (dynamic_cast<Quadrangle *>(Figures[i])){
			Figures[i]->MoveTo(flag);
		}
	}COpenGLView::OnShowmassive();
}


void COpenGLView::OnMoveellips()
{
	//37 - left; 38 -up;39- right;40-down
	int flag =37+ rand() / (RAND_MAX / 3);
	for (int i = 0; i < Figures.size(); i++){
		if (dynamic_cast<Ellipsoid *>(Figures[i])){
			Figures[i]->MoveTo(flag);
		}
	}
	COpenGLView::OnShowmassive();
}

void COpenGLView::OnRotation()
{

	for (int i = 0; i < Figures.size();i++){
		if (dynamic_cast<Line *>(Figures[i])){
			Figures[i]->ChangeAngle();
		}
		if (dynamic_cast<Ellipsoid *>(Figures[i]) || dynamic_cast<Quadrangle *>(Figures[i]) || dynamic_cast<Rhombus *>(Figures[i])){
			Figures[i]->Rotate();
		}
	}
	COpenGLView::OnShowmassive();
}


void COpenGLView::OnChangeradius()
{
	for (int i = 0; i < Figures.size(); i++){
		if (dynamic_cast<Circle *>(Figures[i])){
			Figures[i]->Resize();
		}
	}
	COpenGLView::OnShowmassive();
}

void COpenGLView::OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags)//стрелка вверх-вверх;стр влево-влево;...-вправо;...-вниз
{
	for (int i = 0; i < Figures.size(); i++){
		Figures[i]->MoveTo(nChar);
	}
	COpenGLView::OnShowmassive();
	//38 -up;37 - left; 39- right;40-down
	/*const size_t len = 256;
	wchar_t buffer[len] = {};
	_snwprintf(buffer, len - 1, L"X: %d", nChar);
	AfxMessageBox(buffer);*/
}

void COpenGLView::OnDestroymassive()//уничтожаем массив
{
	for (int i = 0; i < Figures.size(); i++){
		delete Figures[i];
		Figures[i] = NULL;
	}
	Figures.clear();
	COpenGLView::OnClearmassive();
}

void COpenGLView::OnClearmassive()//стираем изображение
{
	glClear(GL_COLOR_BUFFER_BIT);
	SwapBuffers(wglGetCurrentDC());
}

void COpenGLView::OnShowmassive()//выводим массив на экран
{
	glClear(GL_COLOR_BUFFER_BIT);
	for (int i = 0; i < Figures.size(); i++){
		Figures[i]->Show();
	}
	SwapBuffers(wglGetCurrentDC());
}

void COpenGLView::OnCreatemassive()//создаем массив
{
	enum objects{ Circ=0, Li, Elli, Quadr, Rhomb };//перечисление классов
	for (int i = 0; i < 30; i++){
		int flag = rand() / (RAND_MAX / 5);
		switch (flag){
			case Circ:{
					Figures.push_back(new Circle());
					break;
			}
			case Li:{
						Figures.push_back(new Line());
						break;
			}
			case Elli:{
						Figures.push_back(new Ellipsoid());
						break;
			}
			case Quadr:{
						Figures.push_back(new Quadrangle());
						break;
			}
			case Rhomb:{
						Figures.push_back(new Rhombus());
						break;
			}
		}
	}
	
	/*const size_t len = 256;
	wchar_t buffer[len] = {};
	_snwprintf(buffer, len - 1, L"X: %d", flag);
	AfxMessageBox(buffer);*/
}

void COpenGLView::display()
{
	/*glClear(GL_COLOR_BUFFER_BIT);
	for (int i = 0; i < Figures.size(); i++){
		Figures[i]->Show();
	}
	SwapBuffers(wglGetCurrentDC());*/
}


void COpenGLView::OnSize(UINT nType, int cx, int cy)
{
	CView::OnSize(nType, cx, cy);
	glViewport(0, 0, cx, cy);//окно просмотра
	glClearColor(1.0, 1.0, 0.0, 0.0);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(0, 0, cx, cy);
}
BOOL COpenGLView::PreCreateWindow(CREATESTRUCT& cs)//задаем стили окна
{
	return CView::PreCreateWindow(cs);
}

// рисование COpenGLView

void COpenGLView::OnDraw(CDC* /*pDC*/)//вызывается при изменении размеров окна и т.д.
{
	COpenGLView::OnShowmassive();
	COpenGLDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;
}


// диагностика COpenGLView

#ifdef _DEBUG
void COpenGLView::AssertValid() const
{
	CView::AssertValid();
}

void COpenGLView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

COpenGLDoc* COpenGLView::GetDocument() const // встроена неотлаженная версия
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(COpenGLDoc)));
	return (COpenGLDoc*)m_pDocument;
}
#endif //_DEBUG


// обработчики сообщений COpenGLView


int COpenGLView::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	//SetWindowPos(&wndTop, 0, 0, 100, 100, SWP_NOMOVE);
	if (CView::OnCreate(lpCreateStruct) == -1)return -1;
    pdc = new CClientDC(this);//инициализация формы - создание клиентской области окна
	SetWindowPos(&wndTop, 0, 0, 1200, 1200, SWP_NOMOVE);
    if(SetWindowPixelFormat(pdc->m_hDC)==FALSE)return -1;//  (3.Разместить на форме компонент Image для отображения примитивов и выровнять его на всю клиентскую область)
    hGLRC = wglCreateContext(pdc->m_hDC);//вщзвращает хендл к opengl
    if(hGLRC == NULL)return -1;
    if(wglMakeCurrent(pdc->m_hDC, hGLRC)==FALSE)return -1;// Получить контекст в своё распоряжение
    return 0;
}

int COpenGLView::SetWindowPixelFormat(HDC hDC)
{
	int m_GLPixelIndex;
	PIXELFORMATDESCRIPTOR pfd;//создаем структуру типа PIXELFORMATDESCRIPTOR и заполняем её далее
	pfd.nSize = sizeof(pfd);
	pfd.nVersion = 1;
	pfd.dwFlags = PFD_DRAW_TO_WINDOW |
		PFD_SUPPORT_OPENGL |
		PFD_DOUBLEBUFFER;
	pfd.iPixelType = PFD_TYPE_RGBA;
	pfd.cColorBits = 32;
	pfd.cRedBits = 8;
	pfd.cRedShift = 16;
	pfd.cGreenBits = 8;
	pfd.cGreenShift = 8;
	pfd.cBlueBits = 8;
	pfd.cBlueShift = 0;
	pfd.cAlphaBits = 0;
	pfd.cAlphaShift = 0;
	pfd.cAccumBits = 64;
	pfd.cAccumRedBits = 16;
	pfd.cAccumGreenBits = 16;
	pfd.cAccumBlueBits = 16;
	pfd.cAccumAlphaBits = 0;
	pfd.cDepthBits = 32;
	pfd.cStencilBits = 8;
	pfd.cAuxBuffers = 0;
	pfd.iLayerType = PFD_MAIN_PLANE;
	pfd.bReserved = 0;
	pfd.dwLayerMask = 0;
	pfd.dwVisibleMask = 0;
	pfd.dwDamageMask = 0;
	m_GLPixelIndex = ChoosePixelFormat(hDC, &pfd);//запрос на выбор самого подходящего формата

	if (m_GLPixelIndex == 0) // Let's choose a default index.
	{
		m_GLPixelIndex = 1;//подбируаем другой формат
		if (DescribePixelFormat(hDC, m_GLPixelIndex, sizeof(PIXELFORMATDESCRIPTOR), &pfd) == 0)return 0;
	}
	if (SetPixelFormat(hDC, m_GLPixelIndex, &pfd) == FALSE){//Если формат был успешно подобран, нужно его выставить функцией SetPixelFormat
		 return 0;
	}
	return 1;
}

void COpenGLView::OnDestroy()
{
	if (wglGetCurrentContext() != NULL)
		wglMakeCurrent(NULL, NULL);
	if (hGLRC != NULL)
	{
		wglDeleteContext(hGLRC);
		hGLRC = NULL;
	}
	delete pdc;
	CView::OnDestroy();
}
