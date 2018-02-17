
// OpenGLView.h : ��������� ������ COpenGLView
//

#pragma once


class COpenGLView : public CView
{
private:
	CClientDC *pdc;
	HGLRC hGLRC;
	int SetWindowPixelFormat(HDC);
protected: // ������� ������ �� ������������
	COpenGLView();
	DECLARE_DYNCREATE(COpenGLView)

// ��������
public:
	COpenGLDoc* GetDocument() const;
	void display();
// ��������
public:

// ���������������
public:
	virtual void OnDraw(CDC* pDC);  // �������������� ��� ��������� ����� �������������
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:

// ����������
public:
	virtual ~COpenGLView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// ��������� ������� ����� ���������
protected:
	DECLARE_MESSAGE_MAP()
public:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnDestroy();
	afx_msg void OnSize(UINT nType, int cx, int cy);
	afx_msg void Onsphere();
	afx_msg void On32774();
	afx_msg void On32775();
	afx_msg void On32776();
	afx_msg void On32777();
	afx_msg void On32778();
	afx_msg void On32779();
};

#ifndef _DEBUG  // ���������� ������ � OpenGLView.cpp
inline COpenGLDoc* COpenGLView::GetDocument() const
   { return reinterpret_cast<COpenGLDoc*>(m_pDocument); }
#endif

