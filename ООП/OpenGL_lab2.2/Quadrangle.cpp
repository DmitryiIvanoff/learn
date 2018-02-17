#include "stdafx.h"
#include "Quadrangle.h"


Quadrangle::Quadrangle() :ТFigure()
{
	//определяем оставшиеся 3 точки - делаем их зависимыми от базовых x и y , определенных в TFigure()
	x1 =x + (float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1;
	y1 = y;// +(float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1;
	x2 = x1;// +(float)rand() * (0.2 - 0.1) / RAND_MAX + 0.1;
	y2 = y+(float)rand() * (0.2 - 0.1) / RAND_MAX + 0.1;
	x3 = x;//x;// +(float)rand() * (0.4 - 0.1) / RAND_MAX + 0.1;
	y3 = y2;// y2;// +(float)rand() * (0.4 - 0.1) / RAND_MAX + 0.1;
	Edit();

}

void Quadrangle::Rotate(){
	rotation == 360 ? rotation = 0 : rotation = rotation;
	rotation += 90;
	Show();
}

Quadrangle::Quadrangle(float dx, float dy, float dx1, float dy1, float  dx2, float  dy2, float  dx3, float  dy3) :ТFigure(dx,dy){
	x1 = dx1;
	x2 = dx2;
	x3 = dx3;
	y1 = dy1;
	y2 = dy2;
	y3 = dy3;
	Edit();
}

void Quadrangle::Show(){
	glPointSize(2);
	glPushMatrix();
	glColor3d(1, 0, 0);
	//glTranslatef(-x, -y, 0);
	glRotatef((float)rotation, 0, 0, 1.0f);
	//glTranslatef(x, y, 0);
	float mx[4] = { x, x1, x2, x3 };
	float my[4] = { y, y1, y2, y3 };
	glBegin(GL_QUADS);
	for (int i = 0; i<sizeof(mx) / sizeof(mx[0]); i++){
		glVertex2f(mx[i], my[i]);
	}
	glEnd();
	glPopMatrix();
}
Quadrangle::~Quadrangle()
{
}

void Quadrangle::MoveTo(){//реализуем свой метод
	float deltaX = -1.0f + (float)rand() / (RAND_MAX / 2.0f);
	float deltaY = -1.0f + (float)rand() / (RAND_MAX / 2.0f);
	x += deltaX;
	y += deltaY;
	x1 += deltaX;
	x2 += deltaX;
	x3 += deltaX;
	y1 += deltaY;
	y2 += deltaY;
	y3 += deltaY;
	Edit();
	Show();
};

void Quadrangle::Edit(){
	float *mx[4] = { &x, &x1, &x2, &x3 };
	float *my[4] = { &y, &y1, &y2, &y3 };
	for (int i = 0; i<sizeof(mx) / sizeof(mx[0]); i++){
		if (abs(*mx[i])>1.0f){
			float delta = abs(*mx[i]) - 1.0f;
			//смещаем сразу все точки на одинаковое расстояние чтобы сохранить пропорции
			for (int j = 0;j<sizeof(mx)/sizeof(mx[0]);j++){
				(*mx[i])>0 ? (*mx[j])-=delta:(*mx[j])+=delta ;
			}
			/*const size_t len = 256;
			wchar_t buffer[len] = {};
			_snwprintf(buffer, len - 1, L"X: %f=%f %f=%f %f=%f %f=%f delta=%f", mx[0],x, mx[1],x1, mx[2],x2, mx[3],x3, delta);
			AfxMessageBox(buffer);*/
			i = 0;//проверяем заново
		}
	}
	for (int i = 0; i<sizeof(my) / sizeof(my[0]); i++){
		if (abs(*my[i])>1.0f){
			float delta = abs(*my[i]) - 1.0f;
			//смещаем сразу все точки на одинаковое расстояние чтобы сохранить пропорции
			for (int j = 0; j<sizeof(my) / sizeof(my[0]); j++){
				(*my[i])>0 ? (*my[j]) -= delta : (*my[j]) += delta;
			}
			/*const size_t len = 256;
			wchar_t buffer[len] = {};
			_snwprintf(buffer, len - 1, L"Y: %f=%f %f=%f %f=%f %f=%f delta=%f", my[0],y, my[1],y1, my[2],y2, my[3],y3, delta);
			AfxMessageBox(buffer);*/
			i = 0;
		}
	}
}