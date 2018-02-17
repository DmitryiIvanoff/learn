#include "stdafx.h"
#include "Line.h"
#include <iostream>


Line::Line()
{
	l = (float)rand() * (1 - 0.1) / RAND_MAX + 0.1;
	a = rand() * (360) / RAND_MAX;
	Edit(begin);
	AfxMessageBox(L"Отрезок создан");
}
Line::Line(float xn, float yn, float ln, int an) :begin(xn, yn), l(ln), a(an){
	Edit(begin);
	AfxMessageBox(L"Отрезок создан");
};

void Line::Edit(Point &p){
	if (abs(p.GetX()) + l > 1){
		p.Set(p.GetX()>0 ? p.GetX() - l : p.GetX() + l, p.GetY());
	}
	if (l + abs(p.GetY()) > 1){
		p.Set(p.GetX(), p.GetY()>0 ? p.GetY() - l : p.GetY() + l);
	}
};

Line::~Line()
{
	//std::cout << "Line has been deleted";
}

void Line::Show(){
	//glClear(GL_COLOR_BUFFER_BIT);
	glPointSize(2);
	glBegin(GL_POINTS);
	glColor3d(0, 1, 1);
	glVertex2i(begin.GetX(), begin.GetY());
	glEnd();

	glBegin(GL_LINES);
	glColor3d(1, 0, 0);
	glVertex2f((float)begin.GetX(), (float)begin.GetY());
	glVertex2f((cos(a) * (float)l) + (float)begin.GetX(), (sin(a) * (float)l) + (float)begin.GetY());
	glEnd();
	glFlush();
};
void Line::MoveTo(){
	begin = Point();
	Edit(begin);
	Show();
};
void Line::ChangeAngle(){
	a = rand() * (360) / RAND_MAX; 
	Edit(begin);
	Show();
};