#pragma once
#include "�Figure.h"
class Line :public �Figure
{
	float l;int a; //x, y ��������� � ������� ������
public:
	Line();
	Line(float x, float y, float l, int a);
	virtual  ~Line();
	virtual void Show();
	virtual void Edit();
	virtual void MoveTo();
	void ChangeAngle();
};

