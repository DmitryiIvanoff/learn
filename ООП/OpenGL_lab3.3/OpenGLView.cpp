
// OpenGLView.cpp : ���������� ������ COpenGLView
//

#include "stdafx.h"
#include "MyContainer.h"
// SHARED_HANDLERS ����� ���������� � ������������ �������� ��������� ���������� ������� ATL, �������
// � ������; ��������� ��������� ������������ ��� ��������� � ������ �������.
#ifndef SHARED_HANDLERS
#include "OpenGL.h"
#endif

#include "OpenGLDoc.h"
#include "OpenGLView.h"
#include "�Figure.h"
#include "Circle.h"
#include "Line.h"
#include "Ellipsoid.h"
#include "Quadrangle.h"
#include "Rhombus.h"
#include <iostream>
#include <algorithm>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif
HWND hWnd;
HGLRC hGLRC;

MyContainer cont;

IMPLEMENT_DYNCREATE(COpenGLView, CView)

BEGIN_MESSAGE_MAP(COpenGLView, CView)
	ON_WM_CREATE()
	ON_WM_DESTROY()
	ON_WM_SIZE()
	ON_WM_KEYDOWN()//��������� ��������� ����������
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
	cont.Give('d', 0);
	COpenGLView::OnShowmassive();
}


void COpenGLView::OnMoveline()
{
	cont.Give('l', 0);
	COpenGLView::OnShowmassive();
}


void COpenGLView::OnMoveromb()
{
	cont.Give('o', 0);
	COpenGLView::OnShowmassive();
}


void COpenGLView::OnMovesquare()
{
	cont.Give('q', 0);
	COpenGLView::OnShowmassive();
}


void COpenGLView::OnMoveellips()
{
	cont.Give('e', 0);
	COpenGLView::OnShowmassive();
}

void COpenGLView::OnRotation()
{
	cont.Give('t', 0);
	COpenGLView::OnShowmassive();
}


void COpenGLView::OnChangeradius()
{
	cont.Give('r', 0);
	COpenGLView::OnShowmassive();
}

void COpenGLView::OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags)//������� �����-�����;��� �����-�����;...-������;...-����
{
	cont.Give('m', nChar);
	COpenGLView::OnShowmassive();
}

void COpenGLView::OnDestroymassive()//���������� ������
{
	delete &cont;
	COpenGLView::OnClearmassive();
}

void COpenGLView::OnClearmassive()//������� �����������
{
	glClear(GL_COLOR_BUFFER_BIT);
	SwapBuffers(wglGetCurrentDC());
}

void COpenGLView::OnShowmassive()//������� ������ �� �����
{
	glClear(GL_COLOR_BUFFER_BIT);
	cont.Give('s',0);
	SwapBuffers(wglGetCurrentDC());
}

void COpenGLView::OnCreatemassive()//������� ������
{
	enum objects{ Circ=0, Li, Elli, Quadr, Rhomb };//������������ �������
	for (int i = 0; i < 30; i++){
		int flag = rand() / (RAND_MAX / 5);
		switch (flag){
			case Circ:{
						  cont.Add(new Circle());
					break;
			}
			case Li:{
						cont.Add(new Line());
						break;
			}
			case Elli:{
						  cont.Add(new Ellipsoid());
						break;
			}
			case Quadr:{
						   cont.Add(new Quadrangle());
						break;
			}
			case Rhomb:{
						   cont.Add(new Rhombus());
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
	glViewport(0, 0, cx, cy);//���� ���������
	glClearColor(1.0, 1.0, 0.0, 0.0);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(0, 0, cx, cy);
}
BOOL COpenGLView::PreCreateWindow(CREATESTRUCT& cs)//������ ����� ����
{
	return CView::PreCreateWindow(cs);
}

// ��������� COpenGLView

void COpenGLView::OnDraw(CDC* /*pDC*/)//���������� ��� ��������� �������� ���� � �.�.
{
	COpenGLView::OnShowmassive();
	COpenGLDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;
}


// ����������� COpenGLView

#ifdef _DEBUG
void COpenGLView::AssertValid() const
{
	CView::AssertValid();
}

void COpenGLView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

COpenGLDoc* COpenGLView::GetDocument() const // �������� ������������ ������
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(COpenGLDoc)));
	return (COpenGLDoc*)m_pDocument;
}
#endif //_DEBUG


// ����������� ��������� COpenGLView


int COpenGLView::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	//SetWindowPos(&wndTop, 0, 0, 100, 100, SWP_NOMOVE);
	if (CView::OnCreate(lpCreateStruct) == -1)return -1;
    pdc = new CClientDC(this);//������������� ����� - �������� ���������� ������� ����
	SetWindowPos(&wndTop, 0, 0, 1200, 1200, SWP_NOMOVE);
    if(SetWindowPixelFormat(pdc->m_hDC)==FALSE)return -1;//  (3.���������� �� ����� ��������� Image ��� ����������� ���������� � ��������� ��� �� ��� ���������� �������)
    hGLRC = wglCreateContext(pdc->m_hDC);//���������� ����� � opengl
    if(hGLRC == NULL)return -1;
    if(wglMakeCurrent(pdc->m_hDC, hGLRC)==FALSE)return -1;// �������� �������� � ��� ������������
    return 0;
}

int COpenGLView::SetWindowPixelFormat(HDC hDC)
{
	int m_GLPixelIndex;
	PIXELFORMATDESCRIPTOR pfd;//������� ��������� ���� PIXELFORMATDESCRIPTOR � ��������� � �����
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
	m_GLPixelIndex = ChoosePixelFormat(hDC, &pfd);//������ �� ����� ������ ����������� �������

	if (m_GLPixelIndex == 0) // Let's choose a default index.
	{
		m_GLPixelIndex = 1;//���������� ������ ������
		if (DescribePixelFormat(hDC, m_GLPixelIndex, sizeof(PIXELFORMATDESCRIPTOR), &pfd) == 0)return 0;
	}
	if (SetPixelFormat(hDC, m_GLPixelIndex, &pfd) == FALSE){//���� ������ ��� ������� ��������, ����� ��� ��������� �������� SetPixelFormat
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
