#pragma once
#include "�Figure.h"
class Circle :public �Figure
{
protected:
	float r; //x,y -��������� � ������� ������
public:
	Circle(float dx, float dy, float dr) ;
	Circle();

	virtual  ~Circle();
	void Show();
	virtual void Edit();
	void Resize();
};

