#include "stdafx.h"
#include "�Figure.h"

�Figure::�Figure(){
	x = -1.0f + (float)rand() / (RAND_MAX / 2.0f);
	y = -1.0f + (float)rand() / (RAND_MAX / 2.0f);
	AfxMessageBox(L"������ �������");
}

�Figure::�Figure(float dx,float dy){
	x = dx;
	y = dy;
	AfxMessageBox(L"������ �������");
}
void �Figure::MoveTo(){
	x = -1.0f + (float)rand() / (RAND_MAX / 2.0f);
	y = -1.0f + (float)rand() / (RAND_MAX / 2.0f);
	Edit();
	Show();
}

�Figure::~�Figure()
{
}
