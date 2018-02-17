#include "stdafx.h"
#include "Line.h"
#include <iostream>


Line::Line() :ТFigure()
{
	l = (float)rand() * (1 - 0.1) / RAND_MAX + 0.1;
	a = rand() * (360) / RAND_MAX;
	Edit(); Show();
}
Line::Line(float xn, float yn, float ln, int an) :ТFigure(xn, yn){
	 l = ln; a = an;
	Edit();
};

void Line::Edit(){//контроль за выходом за пределы изображения
	if (abs(x) + l > 1){
		x>0 ? x -= l : x += l;
	}
	if (l*sin(a) + abs(y) > 1){
		y > 0 ? y -= l : y += l;
	}
}

Line::~Line()
{
	//std::cout << "Line has been deleted";
}

void Line::Show(){
	//glClear(GL_COLOR_BUFFER_BIT);
	glPointSize(2);
	glBegin(GL_LINES);
	glColor3d(1, 0.2, 1);
	glVertex2f((float)x, (float)y);
	glVertex2f((cos(a) * (float)l) + (float)x, (sin(a) * (float)l) + (float)y);
	glEnd();
	glFlush();
};
void Line::MoveTo(){
	x = (float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1;
	y = (float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1;
	Edit();
	Show();
};
void Line::ChangeAngle(){
	a = rand() * (360) / RAND_MAX;
	Edit();
	Show();
};