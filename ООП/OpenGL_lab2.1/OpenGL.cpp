
// OpenGL.cpp : ���������� ��������� ������� ��� ����������.
//

#include "stdafx.h"
#include "afxwinappex.h"
#include "afxdialogex.h"
#include "OpenGL.h"
#include "MainFrm.h"

#include "OpenGLDoc.h"
#include "OpenGLView.h"
#include "Circle.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// COpenGLApp

BEGIN_MESSAGE_MAP(COpenGLApp, CWinApp)
	ON_COMMAND(ID_APP_ABOUT, &COpenGLApp::OnAppAbout)
	// ����������� ������� �� ������ � ������� ����������
	ON_COMMAND(ID_FILE_NEW, &CWinApp::OnFileNew)
	ON_COMMAND(ID_FILE_OPEN, &CWinApp::OnFileOpen)
	ON_COMMAND(ID_sphere, &COpenGLApp::Onsphere)
END_MESSAGE_MAP()


// �������� COpenGLApp

COpenGLApp::COpenGLApp()
{
	// TODO: �������� ���� ������ �������������� ���������� ������� ����������� ��������������; �������������
	// ������ ��� ������: �����������.�����������.����������.���������������
	SetAppID(_T("OpenGL.AppID.NoVersion"));

	// TODO: �������� ��� ��������,
	// ��������� ���� ������ ��� ������������� � InitInstance
}

BOOL COpenGLApp::OnIdle(LONG lCount)// ��� ������� ���������� ������ ���, ����� ������� ��������� ���� �����
{
	((COpenGLView*)((CMainFrame*)m_pMainWnd)->GetActiveView())->display();
	return 1;//CWinApp::OnIdle(lCount);
}

void COpenGLApp::Onsphere()
{
	//((COpenGLView*)((CMainFrame*)m_pMainWnd)->GetActiveView())->display();
	// TODO: �������� ���� ��� ����������� ������
}
// ������������ ������ COpenGLApp

COpenGLApp theApp;


// ������������� COpenGLApp

BOOL COpenGLApp::InitInstance()
{
	CWinApp::InitInstance();


	EnableTaskbarInteraction(FALSE);

	// ��� ������������� �������� ���������� RichEdit ��������� ����� AfxInitRichEdit2()	
	// AfxInitRichEdit2();

	// ����������� �������������
	// ���� ��� ����������� �� ������������ � ���������� ��������� ������
	// ��������� ������������ �����, ���������� ������� �� ����������
	// ���������� ��������� �������������, ������� �� ���������
	// �������� ������ �������, � ������� �������� ���������
	// TODO: ������� �������� ��� ������ �� ���-������ ����������,
	// �������� �� �������� �����������
	SetRegistryKey(_T("��������� ����������, ��������� � ������� ������� ����������"));
	LoadStdProfileSettings(4);  // ��������� ����������� ��������� INI-����� (������� MRU)


	// ��������������� ������� ���������� ����������.  ������� ����������
	//  ��������� � ���� ���������� ����� �����������, ������ ����� � ���������������
	CSingleDocTemplate* pDocTemplate;
	pDocTemplate = new CSingleDocTemplate(
		IDR_MAINFRAME,
		RUNTIME_CLASS(COpenGLDoc),
		RUNTIME_CLASS(CMainFrame),       // �������� ���� ����� SDI
		RUNTIME_CLASS(COpenGLView));
	if (!pDocTemplate)
		return FALSE;
	AddDocTemplate(pDocTemplate);


	// ��������� ������������� ����������� �������� � ������� �������� ����
	CMFCToolBar::m_bExtCharTranslation = TRUE;

	// �������������� ������ ��������� ������ �� ����������� ������� ��������, DDE, �������� ������
	CCommandLineInfo cmdInfo;
	ParseCommandLine(cmdInfo);



	// ������� ���������������, ��������� � ��������� ������.  �������� FALSE ����� ����������, ����
	// ���������� ���� �������� � ���������� /RegServer, /Register, /Unregserver ��� /Unregister.
	if (!ProcessShellCommand(cmdInfo))
		return FALSE;

	// ���� � ������ ���� ���� ���� ����������������, ������� ���������� � �������� ���
	m_pMainWnd->ShowWindow(SW_SHOW);
	m_pMainWnd->UpdateWindow();
	//((COpenGLView*)((CMainFrame*)m_pMainWnd)->GetActiveView())->display();
	return TRUE;
}

// ����������� ��������� COpenGLApp


// ���������� ���� CAboutDlg ������������ ��� �������� �������� � ����������

class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

// ������ ����������� ����
	enum { IDD = IDD_ABOUTBOX };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // ��������� DDX/DDV

// ����������
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialogEx(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialogEx)
END_MESSAGE_MAP()

// ������� ���������� ��� ������� �������
void COpenGLApp::OnAppAbout()
{
	CAboutDlg aboutDlg;
	aboutDlg.DoModal();
}

// ����������� ��������� COpenGLApp

