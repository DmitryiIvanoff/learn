#pragma once
#include "�Figure.h"
class Quadrangle :
	public �Figure
{
protected:
	float x1,x2,x3,y1,y2,y3;//���������� ��� 3 ��������� ������
	int rotation=0;
public:
	Quadrangle();
	Quadrangle(float dx,float dy,float dx1, float dy1, float  dx2, float  dy2, float  dx3, float  dy3);
	virtual void Show();
	virtual void Edit();
	virtual void MoveTo();
	virtual void Rotate();
	virtual ~Quadrangle();
};

