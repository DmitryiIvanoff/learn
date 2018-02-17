#include "stdafx.h"
#include "Circle.h"
#include <iostream>

Circle::Circle(){
	x = -1.0f + (float)rand() / (RAND_MAX / 2.0f);
	y = -1.0f + (float)rand() / (RAND_MAX / 2.0f);
	r = (float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1;
	Edit();
};
Circle::Circle(float dx, float dy, float dr)
{
	x = dx; y = dy; r = dr; Edit();
}

void Circle::Edit(){//контроль за выходом за пределы изображения
	if (abs(x) + r > 1){
		x>0 ? x-= r : x+= r;
	}
	if (r + abs(y) > 1){
		y > 0 ? y-= r : y+= r;
	}
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
	glVertex2i(x, y); // вершина в центре круга
	glEnd();

	glBegin(GL_LINE_LOOP);
	for (int i = 0; i <= 50; i++) {
		float a = (float)i / 50.0f * 3.1415f * 2.0f;
		glVertex2f((cos(a) * (float)r) + (float)x, (sin(a) * (float)r) + (float)y);
	}
	glEnd(); 
	glFlush();
}
void Circle::MoveTo(){

	x = -1.0f + (float)rand() / (RAND_MAX / 2.0f);
	y = -1.0f + (float)rand() / (RAND_MAX / 2.0f);
	Edit();
	Show();
}
void Circle::Resize(){
	r = (float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1; 
	Edit();
	Show();
}
