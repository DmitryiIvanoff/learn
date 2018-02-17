#include "stdafx.h"
#include "Ring.h"
#include <iostream>

Ring::Ring(){
	//center = Point();//������� ����� ����������
	//x = Point::Point();//(float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1; 
	//y = //(float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1; 
	r = (float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1;
	h = (float)rand() * (0.1 - 0.01) / RAND_MAX + 0.01;
	Edit(center);
	AfxMessageBox(L"������ �������");
};
Ring::Ring(float dx, float dy, float dr, float dh)
{
	center = Point(dx, dy);
	r = dr;
	h = dh;
	Edit(center);
	AfxMessageBox(L"������ �������");
}

void Ring::Edit(Point &p){//�������� �� ������� �� ������� �����������
	if (abs(p.GetX())+r > 1){
		p.Set(p.GetX()>0 ? p.GetX() - r : p.GetX() + r, p.GetY());
	}
	if (r + abs(p.GetY()) > 1){
		p.Set(p.GetX(), p.GetY()>0 ? p.GetY() - r : p.GetY()+r);
	}
}

Ring::~Ring()
{
	gluDeleteQuadric(quadratic);
	//std::cout << "Circle has been deleted";
}

void Ring::Show(){
	quadratic = gluNewQuadric();     // ������� ��������� �� ������������ ������ 
	gluQuadricNormals(quadratic, GLU_SMOOTH); // ������� ������� ������� 
	gluQuadricTexture(quadratic, GL_TRUE);    // ������� ���������� �������� 
	//glClear(GL_COLOR_BUFFER_BIT);
	glPointSize(2);
	glPushMatrix();
	glColor3d(1, 0, 0);
	glTranslatef(center.GetX(), center.GetY(),0);//���������� � �������� ����� ������
	gluDisk(quadratic, r - h, r, 50, 50);
	/*for (int i = 0; i <= 50; i++) {
		float a = (float)i / 50.0f * 3.1415f * 2.0f;
		glVertex2f((cos(a) * (float)r) + (float)center.GetX(), (sin(a) * (float)r) + (float)center.GetY());
	}*/
	glPopMatrix();
	//glFlush();
}
void Ring::MoveTo(){

	//x = (float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1;
	//y = (float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1;
	center = Point();
	Edit(center);
	Show();
}
void Ring::Resize(){
	r = (float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1; 
	Edit(center);
	Show();
}
