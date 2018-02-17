
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
#include "Circle.h"
#include "Line.h"
#include "ТFigure.h"
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
//HDC hDC;
int flag = 0;
Circle *C;
Line *L;
Ellipsoid *E;
Quadrangle *Q;

std::vector<Line*> Lines;
std::vector<Circle*> Circles;
std::vector<Ellipsoid*> Ellipsoides;
std::vector<Quadrangle*> Quadrangles;
// COpenGLView

IMPLEMENT_DYNCREATE(COpenGLView, CView)

BEGIN_MESSAGE_MAP(COpenGLView, CView)
	ON_WM_CREATE()
	ON_WM_DESTROY()
	ON_WM_SIZE()
	ON_COMMAND(ID_sphere, &COpenGLView::Onsphere)
	ON_COMMAND(ID_32774, &COpenGLView::On32774)
	ON_COMMAND(ID_32775, &COpenGLView::On32775)
	ON_COMMAND(ID_32776, &COpenGLView::On32776)
	ON_COMMAND(ID_32777, &COpenGLView::On32777)
	ON_COMMAND(ID_32778, &COpenGLView::On32778)
	ON_COMMAND(ID_32779, &COpenGLView::On32779)
	ON_COMMAND(Ellipce, &COpenGLView::OnEllipce)
	ON_COMMAND(Quadrantles, &COpenGLView::OnQuadrantles)
	ON_COMMAND(Rombus, &COpenGLView::OnRombus)
END_MESSAGE_MAP()

// создание/уничтожение COpenGLView

COpenGLView::COpenGLView()
{
	// TODO: добавьте код создания

}

COpenGLView::~COpenGLView()
{
}
void COpenGLView::On32776()//перемещение
{
	switch (flag){
	case 1:{
			   C->MoveTo();
			   ; break;
	}

	case 2:{
			   L->MoveTo();
			   break;
	}
	case 3:{
			   for (int i = 0; i < Lines.size(); i++){
				   Lines[i]->MoveTo();
			   }
			   for (int i = 0; i < Circles.size();i++){
				   Circles[i]->MoveTo();
			   }
			   for (int i = 0; i < Ellipsoides.size(); i++){
				   Ellipsoides[i]->MoveTo();
			   }
			   for (int i = 0; i < Quadrangles.size(); i++){
				   Quadrangles[i]->MoveTo();
			   }
			   break;
	}
	case 4:{
			   E->MoveTo();
			   break;
	}
	case 5:{
			   Q->MoveTo();
			   break;
	}
	default:break;
	}
}
void COpenGLView::On32777()//создаем массив
{
	flag = 3;
	if (dynamic_cast<Line *>(L)){
		//AfxMessageBox(L"Отрезок удален");
		delete L;
		L = NULL;
	}//проверка на сущ. и удаление объекта
	if (dynamic_cast<Circle *>(C)){
		//AfxMessageBox(L"Окружность удалена");
		delete C;
		C = NULL;
	}//проверка на сущ. и удаление объекта
	if (dynamic_cast<Ellipsoid *>(E)){
		//AfxMessageBox(L"Окружность удалена");
		delete E;
		E = NULL;
	}//проверка на сущ. и удаление объекта
	if (dynamic_cast<Quadrangle *>(Q)){
		//AfxMessageBox(L"Окружность удалена");
		delete Q;
		Q = NULL;
	}//проверка на сущ. и удаление объекта
	Lines.push_back(new Line());
	Circles.push_back(new Circle());
	Ellipsoides.push_back(new Ellipsoid());
	Quadrangles.push_back(new Quadrangle());
	Quadrangles.push_back(new Rhombus());
	for (int i = 0; i < Lines.size();i++){
		Lines[i]->Show();
	}
	for (int i = 0; i < Circles.size(); i++){
		Circles[i]->Show();
	}
	for (int i = 0; i < Ellipsoides.size(); i++){
		Ellipsoides[i]->Show();
	}
	for (int i = 0; i < Quadrangles.size(); i++){
		Quadrangles[i]->Show();
	}
}

void COpenGLView::On32778()//изменить радиус
{
	if (flag==3){
		for (int i = 0; i < Circles.size(); i++){
			Circles[i]->Resize();
		}
		
	}
	else if (flag == 1){
		C->Resize();
	}
	else{
		AfxMessageBox(L"Создайте сначала окружность");
	}
}

void COpenGLView::On32779()//изменить угод наклона отрезка (вращать)
{
	if (flag == 3){
		for (int i = 0; i < Lines.size(); i++){//вращаем линии
			Lines[i]->ChangeAngle();
		}
		for (int i = 0; i < Ellipsoides.size(); i++){//вращаем эллипсы
			Ellipsoides[i]->Rotate();
		}
		for (int i = 0; i < Quadrangles.size(); i++){//вращаем
			Quadrangles[i]->Rotate();
		}
	}
	else if (flag == 2){
		L->ChangeAngle();
	}
	else if (flag == 4){
		E->Rotate();
	}
	else if (flag==5){
		Q->Rotate();
	}
	else{
		AfxMessageBox(L"Создайте сначала отрезок или эллипс");
	}
}

void COpenGLView::On32775()//линия
{
	flag = 2;
	if (dynamic_cast<Line *>(L)){
		//AfxMessageBox(L"Отрезок удален");
		delete L;
		L = NULL;
	}//проверка на сущ. и удаление объекта
	for (int i = 0; i < Circles.size(); i++){//удаляем старые объекты
		delete Circles[i];
		Circles[i] = NULL;
	}
	Circles.clear();
	for (int i = 0; i < Lines.size(); i++){//удаляем старые объекты
		delete Lines[i];
		Lines[i] = NULL;
	}
	Lines.clear();
	for (int i = 0; i < Ellipsoides.size(); i++){//удаляем старые объекты
		delete Ellipsoides[i];
		Ellipsoides[i] = NULL;
	}
	Ellipsoides.clear();
	for (int i = 0; i < Quadrangles.size(); i++){//удаляем старые объекты
		delete Quadrangles[i];
		Quadrangles[i] = NULL;
	}
	Quadrangles.clear();
	Lines.clear();
	L = new Line();
	L->Show();
}

void COpenGLView::OnEllipce()//эллипс
{
	flag = 4;
	if (dynamic_cast<Ellipsoid *>(E)){
		delete E;
		E = NULL;
	}//проверка на сущ. и удаление объекта
	for (int i = 0; i < Circles.size(); i++){//удаляем старые объекты
		delete Circles[i];
		Circles[i] = NULL;
	}
	Circles.clear();
	for (int i = 0; i < Lines.size(); i++){//удаляем старые объекты
		delete Lines[i];
		Lines[i] = NULL;
	}
	Lines.clear();
	for (int i = 0; i < Ellipsoides.size(); i++){//удаляем старые объекты
		delete Ellipsoides[i];
		Ellipsoides[i] = NULL;
	}
	Ellipsoides.clear();
	for (int i = 0; i < Quadrangles.size(); i++){//удаляем старые объекты
		delete Quadrangles[i];
		Quadrangles[i] = NULL;
	}
	Quadrangles.clear();
	E = new Ellipsoid();
	E->Show();
}

void COpenGLView::OnRombus()//ромб
{
	flag = 5;
	if (dynamic_cast<Quadrangle *>(Q)){
		delete Q;
		Q = NULL;
	}//проверка на сущ. и удаление объекта
	for (int i = 0; i < Circles.size(); i++){//удаляем старые объекты
		delete Circles[i];
		Circles[i] = NULL;
	}
	Circles.clear();
	for (int i = 0; i < Lines.size(); i++){//удаляем старые объекты
		delete Lines[i];
		Lines[i] = NULL;
	}
	Lines.clear();
	for (int i = 0; i < Ellipsoides.size(); i++){//удаляем старые объекты
		delete Ellipsoides[i];
		Ellipsoides[i] = NULL;
	}
	Ellipsoides.clear();
	for (int i = 0; i < Quadrangles.size(); i++){//удаляем старые объекты
		delete Quadrangles[i];
		Quadrangles[i] = NULL;
	}
	Quadrangles.clear();
	Q = new Rhombus();
	Q->Show();
}

void COpenGLView::OnQuadrantles()//четырехугольники
{
	flag = 5;
	if (dynamic_cast<Quadrangle *>(Q)){
		delete Q;
		Q = NULL;
	}//проверка на сущ. и удаление объекта
	for (int i = 0; i < Circles.size(); i++){//удаляем старые объекты
		delete Circles[i];
		Circles[i] = NULL;
	}
	Circles.clear();
	for (int i = 0; i < Lines.size(); i++){//удаляем старые объекты
		delete Lines[i];
		Lines[i] = NULL;
	}
	Lines.clear();
	for (int i = 0; i < Ellipsoides.size(); i++){//удаляем старые объекты
		delete Ellipsoides[i];
		Ellipsoides[i] = NULL;
	}
	Ellipsoides.clear();
	for (int i = 0; i < Quadrangles.size(); i++){//удаляем старые объекты
		delete Quadrangles[i];
		Quadrangles[i] = NULL;
	}
	Quadrangles.clear();
	Q = new Quadrangle();
	Q->Show();
}

void COpenGLView::On32774()//окружность
{
	flag = 1;
	if (dynamic_cast<Circle *>(C)){
		//AfxMessageBox(L"Окружность удалена");
		delete C;
		C = NULL;
	}//проверка на сущ. и удаление объекта
	for (int i = 0; i < Circles.size(); i++){//удаляем старые объекты
		delete Circles[i];
		Circles[i] = NULL;
	}
	Circles.clear();
	for (int i = 0; i < Lines.size(); i++){//удаляем старые объекты
		delete Lines[i];
		Lines[i] = NULL;
	}
	Lines.clear();
	for (int i = 0; i < Ellipsoides.size(); i++){//удаляем старые объекты
		delete Ellipsoides[i];
		Ellipsoides[i] = NULL;
	}
	Ellipsoides.clear();
	for (int i = 0; i < Quadrangles.size(); i++){//удаляем старые объекты
		delete Quadrangles[i];
		Quadrangles[i] = NULL;
	}
	Quadrangles.clear();
	C = new Circle();
	C->Show();
	//COpenGLView::display();
	// TODO: добавьте свой код обработчика команд
}


void COpenGLView::display()//
{
	glClear(GL_COLOR_BUFFER_BIT);
	switch (flag){
	case 1:{
			   C->Show();
			   ; break; 
	}
		
	case 2:{
			   L->Show();
			   break;
	}
	case 3:{
			   for (int i = 0; i < Lines.size();i++){
				   Lines[i]->Show();
			   }
			   for (int i = 0; i < Circles.size(); i++){
				   Circles[i]->Show();
			   }
			   for (int i = 0; i < Ellipsoides.size(); i++){
				   Ellipsoides[i]->Show();
			   }
			   for (int i = 0; i < Quadrangles.size(); i++){
				   Quadrangles[i]->Show();
			   }
			   break;
	}
	case 4:{
			   E->Show();
			   break;
	}
	case 5:{
			   Q->Show();
	}
	default:break;
	}
	
	//glTranslated(0.01, 0, 0);-смещение
	//glColor3d(1, 0, 0);
	//auxSolidSphere(1);
	//glFinish();
	SwapBuffers(wglGetCurrentDC());
}


void COpenGLView::OnSize(UINT nType, int cx, int cy)
{
	CView::OnSize(nType, cx, cy);
	glViewport(0, 0, cx, cy);//окно просмотра
	glClearColor(1.0, 1.0, 0.0, 0.0);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(0, 0, cx, cy);


	/*glViewport(0, 0, cx, cy);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	glOrtho(-5, 5, -5, 5, 2, 12);
	gluLookAt(0, 0, 5, 0, 0, 0, 0, 1, 0);
	// gluPerspective(35.0f, (float)cx / (float)cy, 0.01f, 2000.0f);
	glMatrixMode(GL_MODELVIEW);*/
	//COpenGLView::display();
}
BOOL COpenGLView::PreCreateWindow(CREATESTRUCT& cs)//задаем стили окна
{
	//cs.style |= (WS_CLIPCHILDREN | WS_CLIPSIBLINGS);
	return CView::PreCreateWindow(cs);
}

// рисование COpenGLView

void COpenGLView::OnDraw(CDC* /*pDC*/)
{
	COpenGLDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: добавьте здесь код отрисовки для собственных данных
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
	//AfxMessageBox(L"Work 1");
    if(hGLRC == NULL)return -1;
    if(wglMakeCurrent(pdc->m_hDC, hGLRC)==FALSE)return -1;// Получить контекст в своё распоряжение
   /* glEnable(GL_ALPHA_TEST); альфа каналы, материал и т.д.
    glEnable(GL_DEPTH_TEST);
    glEnable(GL_COLOR_MATERIAL);
    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
    glEnable(GL_BLEND);
    glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);*/
    //float pos[4] = {3,3,3,1}; - позиция освещения
   // float dir[3] = {-1,-1,-1}; - //-
    //glLightfv(GL_LIGHT0, GL_POSITION, pos); свет и т.д.
    //glLightfv(GL_LIGHT0, GL_SPOT_DIRECTION, dir);
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




void COpenGLView::Onsphere()
{
	//flag = 1;
	//Circle *C = new Circle(200, 200, 74);
	//C->Show();
	// TODO: добавьте свой код обработчика команд
}

