#pragma once
#include "ТFigure.h"
class Line :public ТFigure
{
	float l;int a; //x, y объявлены в базовом классе
public:
	Line();
	Line(float x, float y, float l, int a);
	virtual  ~Line();
	virtual void Show();
	virtual void Edit();
	virtual void MoveTo();
	void ChangeAngle();
};

