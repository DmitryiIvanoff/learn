#pragma once
#include "ТFigure.h"
class Circle :public ТFigure
{
protected:
	float r; //x,y -объявлены в базовом классе
public:
	Circle(float dx, float dy, float dr) ;
	Circle();

	virtual  ~Circle();
	void Show();
	virtual void Edit();
	void Resize();
};

