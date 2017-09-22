<?php
//define("DB_HOST", "localhost");
//define("DB_USER", "id2988909_root");//dung user cua ban
//define("DB_PASSWORD", "123456");
//define("DB_NAME", "id2988909_apptest");//dung databse name cua ban

define("DB_HOST", "localhost:3306");
define("DB_USER", "root");//dung user cua ban
define("DB_PASSWORD", "");
define("DB_NAME", "students_manager");//dung databse name cua ban


$conn = new mysqli(DB_HOST, DB_USER, DB_PASSWORD, DB_NAME);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 
 mysqli_query($conn, 'SET NAMES "utf8"');
$query = "SELECT * FROM students";
$resouter =  mysqli_query($conn ,$query);
 
$temparray = array();
$total_records = mysqli_num_rows($resouter);
 
if ($total_records >= 1) {
 while ($row = mysqli_fetch_assoc($resouter)) {
        $temparray[] = $row;
    } 
}   
echo json_encode($temparray);
 
?>