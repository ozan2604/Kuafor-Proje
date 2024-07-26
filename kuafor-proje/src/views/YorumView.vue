<template>
   
    <div class="container-fluid" id="baslık">
      <div>
        <h1>Yorumlar</h1>
      </div>
    </div>
    

    <div class="two-columns">
      <div class="left-column">

        <section class="comment-form">
        <h2>Yorum Yap</h2>
        <form @submit.prevent="yorumGonder">
          <label for="kullaniciAdi">Kullanıcı Adı</label>
          <input type="text" placeholder="Kullanıcı Adı Giriniz" v-model="kullaniciAdi" required>

          <label for="YorumDetay">Yorum</label>
          <input type="text" placeholder="Yorum Giriniz" v-model="YorumDetay" required>

          <button type="submit">Gönder</button>
        </form>
        <p>Hesabınız yok mu? <button @click="modalGoster">Kayıt Ol</button></p>
      </section>
      </div>

      <div class="right-column">

        <div class="container">
   
   <section class="comments">
     <h1>Son Yapılan Yorumlar</h1>
     <ul>
       <li v-for="(yorumYaz, index) in sonBesYorumlar" :key="index">
         <div><strong></strong> @{{ yorumYaz.kullaniciAdi }}</div>
         <div><strong></strong> {{ yorumYaz.yorumDetay }}</div>
         <div><strong></strong> {{ formatTarih(yorumYaz.yorumTarih) }}</div>
       </li>
     </ul>
   </section>
 

 <div id="id01" class="modal" v-if="showModal">
   <form class="modal-content animate" @submit.prevent="kullaniciKaydet">
     <div class="container">
       <label for="musteriAdSoyad">Ad Soyad</label>
       <input type="text" placeholder="Ad Soyad" v-model="musteriAdSoyad" required>

       <label for="musteriTel">Telefon Numarası</label>
       <input type="text" placeholder="Telefon Numarası" v-model="musteriTel" required>

       <label for="musteriMail">Mail Adresi</label>
       <input type="text" placeholder="Mail Adresi" v-model="musteriMail" required>

       <label for="kullaniciAdi">Kullanıcı Adı</label>
       <input type="text" placeholder="Kullanıcı Adı" v-model="kullaniciAdi" required>

       <label for="musteriSifre">Şifre</label>
       <input type="password" placeholder="Şifre" v-model="musteriSifre" required>

       <button type="submit">Kaydol</button>
       <button type="button" @click="modalKapat" class="cancelbtn">Geri</button>
     </div>
   </form>
 </div>
</div>


      </div>
    </div>
  
  <div class="container-fluid" id="gizlilik">
      <div class="contact-info">
        <ul v-for="detay in iletişims" :key="detay.id">
          <li>
            <span class="material-icons">call</span>
            <span>{{ detay.İletişimNo }}</span>
          </li>
          <li>
            <span class="material-icons">mail</span>
            <span>{{ detay.İletişimMail }}</span>
          </li>
          <li>
            <span class="material-icons">bolt</span>
            <span>{{ detay.adres }}</span>
          </li>
        </ul>
      </div>
      <p>2024 © Tüm Hakları Saklıdır | Kadir Alkan</p>
    </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      kullaniciAdi: '',
      yorumDetay: '',
      musteriAdSoyad: '',
      musteriTel: '',
      musteriMail: '',
      musteriSifre: '',
      sonBesYorumlar: [],
      showModal: false,

      İletişimNo: '',
      İletişimMail: '',
      adres: '',
      iletişims: []
    };
  },
  created() {
    this.getSonBesYorumlar();
    this.fetchiletisim();
  },
  methods: {
    async fetchiletisim() {
      try {
        const response = await axios.get('https://localhost:7134/api/İletişim/All')
        this.iletişims = response.data.data
      } catch (error) {
        console.error('İletişimler getirilirken bir hata oluştu:', error);
      }
    },
    async getSonBesYorumlar() {
      try {
        const response = await axios.get('https://localhost:7134/api/Yorum/GetSonBesYorum/SonBes');
        this.sonBesYorumlar = response.data;
      } catch (error) {
        console.error('Son 5 yorum getirilirken bir hata oluştu:', error);
      }
    },
    formatTarih(tarih) {
      return new Date(tarih).toLocaleString();
    },
    yorumGonder() {
      const yorum = {
        kullaniciAdi: this.kullaniciAdi,
        YorumDetay: this.YorumDetay
      };

      axios.post('https://localhost:7134/api/Yorum/Save', yorum)
        .then(response => {
          console.log('Yorum gönderildi:', response.data);
          alert('Yorum başarıyla eklendi!');
          this.getSonBesYorumlar();
        })
        .catch(error => {
          console.error('Yorum gönderilirken hata oluştu:', error);
          alert('Yorum eklenirken bir hata oluştu.');
        });

      this.kullaniciAdi = '';
      this.YorumDetay = '';
    },
    modalGoster() {
      this.showModal = true;
    },
    modalKapat() {
      this.showModal = false;
    },
    kullaniciKaydet() {
      const kullanici = {
        MüşteriName: this.musteriAdSoyad,
        MüşteriTelNo: this.musteriTel,
        MüşteriMail: this.musteriMail,
        MüşteriŞifre: this.musteriSifre,
        kullaniciAdi: this.kullaniciAdi
      };

      axios.post('https://localhost:7134/api/Müşteri/Save', kullanici)
        .then(response => {
          console.log('Kullanıcı kaydedildi:', response.data);
          alert('Kullanıcı başarıyla kaydedildi!');
          this.modalKapat();
        })
        .catch(error => {
          console.error('Kullanıcı kaydedilirken hata oluştu:', error);
          alert('Kullanıcı kaydedilirken bir hata oluştu.');
        });

      this.musteriAdSoyad = '';
      this.musteriTel = '';
      this.musteriMail = '';
      this.musteriSifre = '';
      this.kullaniciAdi = '';
    }
  }
};
</script>

<style scoped>

#baslık {
  background-color: black;
  color: #fff;
  height: 100px;
  text-align: center;
  padding: 20px;
}

.two-columns {
  display: flex;
  justify-content: space-around;
  margin: 50px 0;
}


.left-column, .right-column {
  flex: 1;
  padding: 20px;
  box-sizing: border-box;
  
}

h1 {
  text-align: center;
  color: #fff;
}

.left-column{
  margin-bottom: 140px;
}

.right-column {
  font-size: 25px;
  color: black;
  margin-top: 40px;
  
}

#gizlilik {
  background-color: #222;
  color: #fff;
  padding: 30px;
  text-align: left;
}

#gizlilik p {
  margin-top: 20px;
  font-size: 16px;
  text-align: center;
  border-top: 1px solid #444;
  padding-top: 10px;
}

#gizlilik .contact-info {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  margin-bottom: 20px;
}

#gizlilik .contact-info ul {
  list-style: none;
  padding: 0;
}

#gizlilik .contact-info li {
  display: flex;
  align-items: center;
  margin-bottom: 10px;
}

#gizlilik .contact-info span {
  margin-right: 10px;
}



h1, h2 {
  
  size: 20px;
  text-align: center;
 background-color: black;
  color: #fff;
}


.comment-form input, .comment-form button, .modal-content input, .modal-content button {
  width: 100%;
  padding: 10px;
  margin-bottom: 10px;
  border-radius: 5px;
  border: 1px solid #ccc;
}

.comment-form button, .modal-content button {
  background-color: black;
  color: white;
  border: 2px solid black;
  cursor: pointer;
}

.comment-form button:hover, .modal-content button:hover {
  background-color: #555;
}

.comments ul {
  list-style-type: none;
  padding: 0;
}

.comments li {
  background-color: #f9f9f9;
  border: 1px solid #ddd;
  padding: 10px;
  margin-bottom: 10px;
  border-radius: 5px;
}

.comments strong {
  display: block;
  margin-bottom: 5px;
}

.modal {
  display: flex;
  justify-content: center;
  align-items: center;
  position: fixed;
  z-index: 1;
  left: 0;
  top: 0;
  width: 100%;
  height: 100%;
  overflow: auto;
  background-color: rgba(0,0,0,0.4);
}

.modal-content {
  background-color: #fff;
  margin: 5% auto;
  padding: 20px;
  border: 1px solid #888;
  width: 100%;
  max-width: 500px;
  border-radius: 10px;
}

.cancelbtn {
  background-color: #f44336;
}

footer p {
  margin: 0;
}
</style>
