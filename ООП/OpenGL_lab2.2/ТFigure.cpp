#include "stdafx.h"
#include "ÒFigure.h"

ÒFigure::ÒFigure(){
	x = -1.0f + (float)rand() / (RAND_MAX / 2.0f);
	y = -1.0f + (float)rand() / (RAND_MAX / 2.0f);
	AfxMessageBox(L"Ôèãóğà ñîçäàíà");
}

ÒFigure::ÒFigure(float dx,float dy){
	x = dx;
	y = dy;
	AfxMessageBox(L"Ôèãóğà ñîçäàíà");
}
void ÒFigure::MoveTo(){
	x = -1.0f + (float)rand() / (RAND_MAX / 2.0f);
	y = -1.0f + (float)rand() / (RAND_MAX / 2.0f);
	Edit();
	Show();
}

ÒFigure::~ÒFigure()
{
}
