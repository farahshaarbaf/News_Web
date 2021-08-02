<?php

/*
	The Send Mail php Script for Contact Form
	Server-side data validation is also added for good data validation.
*/

$name = $_POST['name'];
$email = $_POST['email'];
$message = $_POST['message'];

if( empty($name) ){
	echo 'لطفا نام خود را وارد کنید.';
}
else if(filter_var($email, FILTER_VALIDATE_EMAIL) == false){
	echo 'لطفا یک ایمیل معتبر وارد کنید.';
}
else if( empty($message) ){
	echo 'لطفا پیام خود را وارد کنید.';
}
else{

	$formcontent="نام: $name\nایمیل: $email\nپیام: $message";

	//Place your Email Here
	$recipient = "info@sample.com";

	$mailheader = "From:$email\r\n";

	if( mail($recipient, 'پیام جدید در سایت', $formcontent, $mailheader) ){
		echo 'success';
	}
	else{
		echo 'error';
	}
}

?>