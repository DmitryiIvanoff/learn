#include "stdafx.h"
#include "“Figure.h"

“Figure::“Figure(){
	x = -1.0f + (float)rand() / (RAND_MAX / 2.0f);
	y = -1.0f + (float)rand() / (RAND_MAX / 2.0f);
	//AfxMessageBox(L"‘Ë„Û‡ ÒÓÁ‰‡Ì‡");
}

“Figure::“Figure(float dx,float dy){
	x = dx;
	y = dy;
	//AfxMessageBox(L"‘Ë„Û‡ ÒÓÁ‰‡Ì‡");
}
void “Figure::MoveTo(int charCode){
	//38 -up;37 - left; 39- right;40-down
	switch (charCode){
	case 37:{
				x -= 0.1; 
				x1 -= 0.1;
				x2 -= 0.1;
				x3 -= 0.1;
				break; 
	}
	case 38:{
				y += 0.1;
				y1 += 0.1;
				y2 += 0.1;
				y3 += 0.1;
				break; 
	}
	case 39:{
				x += 0.1; 
				x1 += 0.1;
				x2 += 0.1;
				x3 += 0.1;
				break; 
	}
	case 40:{
				y -= 0.1; 
				y1 -= 0.1;
				y2 -= 0.1;
				y3 -= 0.1;
				break; 
	}
	}
	Edit();
	Show();
}

void “Figure::ChangeAngle(){

}
void “Figure::Resize(){

}

void “Figure::Rotate(){
	
};

“Figure::~“Figure()
{
}

