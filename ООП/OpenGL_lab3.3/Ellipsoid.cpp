#include "stdafx.h"
#include "Ellipsoid.h"

Ellipsoid::Ellipsoid() :Circle(){//вызов конструктора - родител€
	poluos = (float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1;
	//Edit метода тут нету т.к. он вызываетс€ из наследуемого конструктора
	//AfxMessageBox(L"Ёллипс создан;");
};

Ellipsoid::Ellipsoid(float dx, float dy, float dr, float po) : Circle(dx, dy, dr){//вызов конструктора - родител€
	poluos = po;
	//Edit метода тут нету т.к. он вызываетс€ из наследуемого конструктора
	//AfxMessageBox(L"Ёллипс создан;");
};

void Ellipsoid::Show(){
	glPointSize(2);
	glPushMatrix();
	glColor3d(0.5, 0.5, 0);
	glScalef(1.0f, poluos, 1.0f);
	//glTranslatef(-x, -y, 0);
	glRotatef((float)rotation, 0, 0, 1.0f);
	//glTranslatef(x, y, 0);
	glBegin(GL_LINE_LOOP);
	for (int i = 0; i <= 50; i++) {
		float a = (float)i / 50.0f * 3.1415f * 2.0f;
		glVertex2f((cos(a) * (float)r) + (float)x, (sin(a) * (float)r) + (float)y);
	}
	glEnd();
	glPopMatrix();

};

void Ellipsoid::Rotate(){
	rotation == 360 ? rotation = 0 : rotation = rotation;
	rotation += 90;
	Show();
};

Ellipsoid::~Ellipsoid()
{
}
