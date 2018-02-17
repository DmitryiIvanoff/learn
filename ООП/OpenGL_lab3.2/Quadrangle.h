#pragma once
#include "ÒFigure.h"
class Quadrangle :
	public ÒFigure
{
protected:
	int rotation=0;
public:
	Quadrangle();
	Quadrangle(float dx,float dy,float dx1, float dy1, float  dx2, float  dy2, float  dx3, float  dy3);
	virtual void Show();
	virtual void Edit();
	virtual void Rotate();
	virtual ~Quadrangle();
};

