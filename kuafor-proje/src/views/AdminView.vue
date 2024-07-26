<template>
   <div class="container-fluid">
      <h1>Admin Giriş</h1>
    </div>
   
   <div class="giris">
      <label for="AdminMail"><b>Mail Adresi</b></label> 
            <input type="text" placeholder=" Mail Adresi" v-model="AdminMail" required> 
  
            <label for="AdminŞifre"><b>Şifre</b></label>
            <input type="password" placeholder="Enter Şifre" v-model="AdminŞifre" required>
  
            <button @click="login">Giris</button>
            <p v-if="error" style="color:red;">{{ error }}</p>

            <div class="a">
   <span><strong>Hesabın yok mu? hemen kaydol! {{ s }} </strong></span>

    <button onclick="document.getElementById('id01').style.display='block'" style="width:auto;">Kaydol</button>
   </div>
     </div>
   

<div id="id01" class="modal">
        <form class="modal-content animate" @submit.prevent="adminKaydet">
         
  
          <div class="container">
            <label for="Name"><b>Ad Soyad</b></label>
            <input type="text" placeholder=" Ad Soyad" v-model="Name" required>
  
            <label for="AdminNo"><b>Telefon Numarası</b></label>
            <input type="text" placeholder=" Telefon Numarası" v-model="AdminNo" required>
  
            <label for="AdminMail"><b>Mail Adresi</b></label> 
            <input type="text" placeholder=" Mail Adresi" v-model="AdminMail" required> 
  
            <label for="AdminŞifre"><b>Şifre</b></label>
            <input type="password" placeholder=" Şifre" v-model="AdminŞifre" required>
  
            <button type="submit">Kaydol</button>
            
          </div>

    <div class="container" style="background-color:#f1f1f1">
      <button type="button" onclick="document.getElementById('id01').style.display='none'" class="cancelbtn">Geri</button>
    </div>
  </form>
</div>


</template>

<script>
import axios from 'axios';
export default {

  data(){
    return{
      Name : '',
      AdminNo: '',
      AdminMail:'',
      AdminŞifre: '',
      error: '',
      s:'                          '
      

    };
  },

  methods: {
    modalGoster() {
        document.getElementById('id01').style.display = 'block';
      },
      modalKapat() {
        document.getElementById('id01').style.display = 'none';
      },
    adminKaydet(){
      const admin = {
        Name : this.Name,
        AdminNo : this.AdminNo,
        AdminMail : this.AdminMail,
        AdminŞifre : this.AdminŞifre

      };
       axios.post('https://localhost:7134/api/Admin/Save', admin)
       .then(response => {
            console.log('Admin kaydedildi:', response.data);
            alert('Kullanıcı başarıyla kaydedildi!');
          })
          .catch(error => {
            console.error('Admin kaydedilirken hata oluştu:', error);
            alert('Admin kaydedilirken bir hata oluştu.');
          });

          this.Name = '';
          this.AdminMail ='';
          this.AdminNo='';
          this.AdminŞifre='';

          this.modalKapat();
    }, 

    login(){
      const formData = {
        AdminMail : this.AdminMail,
        AdminŞifre : this.AdminŞifre,
      }

      axios.post('https://localhost:7134/api/Admin/Login', formData  )
      .then(response => {
        console.log(response)
        if(response.status == 201){
          window.location.href = '/AdminBilgi';
        } else{
          throw new Error('Email veya şifre yanlıs');
        }
      })
      .catch(error => {
          this.error = error.message;
        });
    }

  }
}
</script>

<style scoped>

.container-fluid {
  text-align: center;
  background-color: black;
  color: #fff;
  height: 100px;
  padding: 20px;
}

.giris {
  max-width: 600px;
  margin: 75px auto;
  padding: 20px;
  border: 2px solid black;
  border-radius: 5px;
  background-color: #f9f9f9;
  box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
}

input[type=text], input[type=password] {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  box-sizing: border-box;
}

button {
  background-color: black;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 100%;
}

button:hover {
  opacity: 0.8;
}

.cancelbtn {
  width: auto;
  padding: 10px 18px;
  background-color: #f44336;
}

span.psw {
  float: right;
  padding-top: 16px;
}

/* Modal stilleri */
.modal {
  display: none; /* Hidden by default */
  position: fixed; /* Stay in place */
  z-index: 1; /* Sit on top */
  left: 0;
  top: 0;
  width: 100%; /* Full width */
  height: 100%; /* Full height */
  overflow: auto; /* Enable scroll if needed */
  background-color: rgb(0,0,0); /* Fallback color */
  background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
  padding-top: 60px;
}

.modal-content {
  background-color: #fefefe;
  margin: 5% auto 15% auto; /* 5% from the top, 15% from the bottom and centered */
  border: 1px solid #888;
  width: 80%; /* Could be more or less, depending on screen size */
  max-width: 500px;
  border-radius: 10px;
}

/* Modal kapatma butonu */
.close {
  position: absolute;
  right: 25px;
  top: 0;
  color: #000;
  font-size: 35px;
  font-weight: bold;
}

.close:hover,
.close:focus {
  color: red;
  cursor: pointer;
}

/* Zoom animasyonu */
.animate {
  -webkit-animation: animatezoom 0.6s;
  animation: animatezoom 0.6s;
}

@-webkit-keyframes animatezoom {
  from {-webkit-transform: scale(0)} 
  to {-webkit-transform: scale(1)}
}

@keyframes animatezoom {
  from {transform: scale(0)} 
  to {transform: scale(1)}
}

/* Mobil uyumluluk */
@media screen and (max-width: 768px) {
  .giris {
    max-width: 90%;
    margin: 20px auto;
    padding: 15px;
  }

  button {
    padding: 12px 16px;
  }

  .container-fluid {
    padding: 10px;
    height: auto;
  }

  .modal-content {
    width: 90%;
  }
}

@media screen and (max-width: 480px) {
  .container-fluid {
    font-size: 14px;
  }

  button {
    padding: 10px 14px;
  }

  input[type=text], input[type=password] {
    padding: 10px;
    font-size: 14px;
  }

  .giris {
    padding: 10px;
  }
}
</style>
