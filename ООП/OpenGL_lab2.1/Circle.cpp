#include "stdafx.h"
#include "Circle.h"
#include <iostream>

Circle::Circle(){
	//center = Point();//создаем центр окружности
	//x = Point::Point();//(float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1; 
	//y = //(float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1; 
	r = (float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1;
	Edit(center);
	AfxMessageBox(L"Окружность создана");
};
Circle::Circle(float dx, float dy, float dr)
{
	//x = dx; y = dy;
	center = Point(dx, dy);
	r = dr;
	Edit(center);
	AfxMessageBox(L"Окружность создана");
}

Circle::~Circle()
{
	//std::cout << "Circle has been deleted";
}

void Circle::Show(){
	//glClear(GL_COLOR_BUFFER_BIT);
	glPointSize(2);
	glBegin(GL_POINTS);
	glColor3d(1, 0, 0);
	glVertex2i(center.GetX(), center.GetY()); // вершина в центре круга
	glEnd();

	glBegin(GL_LINE_LOOP);
	for (int i = 0; i <= 50; i++) {
		float a = (float)i / 50.0f * 3.1415f * 2.0f;
		glVertex2f((cos(a) * (float)r) + (float)center.GetX(), (sin(a) * (float)r) + (float)center.GetY());
	}
	glEnd(); 
	glFlush();
}

void Circle::Edit(Point &p){//контроль за выходом за пределы изображения
	if (abs(p.GetX()) + r > 1){
		p.Set(p.GetX()>0 ? p.GetX() - r : p.GetX() + r, p.GetY());
	}
	if (r + abs(p.GetY()) > 1){
		p.Set(p.GetX(), p.GetY()>0 ? p.GetY() - r : p.GetY() + r);
	}
}

void Circle::MoveTo(){

	//x = (float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1;
	//y = (float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1;
	center = Point();
	Edit(center);
	Show();
}
void Circle::Resize(){
	r = (float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1;
	Edit(center);
	Show();
}
