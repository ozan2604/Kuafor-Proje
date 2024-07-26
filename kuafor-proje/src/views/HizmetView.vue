<template>
<div>
  <div class="background-container">
    <div class="content">
      <h1>Değişen Dünya</h1>
      <h1>Değişen sen</h1>
    </div>
  </div>

    <div class="two-columns">
        <div class="left-column">
        </div>
        <div class="right-column">

            <ul v-for="detay in services" :key="detay.id">
                 <strong>{{ detay.hizmetAdı }} </strong> <hr>
                <h3>{{ detay.detay }}</h3>
                <p>{{ detay.fiyat }}</p> <hr>  <br>  <br>
            </ul>

        <!-- <strong>Saç Tasarımı</strong> <hr>
        <h3>Mesleğiniz, giyim kuşamınız ve toplumdaki statünüzü göz önünde bulundurarak sadece size özel kafa ve yüz şeklinize göre Anatomik Saç ve Sakal kesimi yapmaktayız.</h3> 
        <P>150 TL</P><hr>  <br>  <br>
        
        <strong>Saç Düzleştirme</strong> <hr>
        <h3>Mesleğiniz, giyim kuşamınız ve toplumdaki statünüzü göz önünde bulundurarak sadece size özel kafa ve yüz şeklinize göre Anatomik Saç ve Sakal kesimi yapmaktayız.</h3>
        <p>100 TL</p> <hr> <br> <br>

        <strong>Kaş Tasarımı</strong> <hr>
        <h3>Kaşlarınızın bakımlı ve güzel olması bakışlarınızı daha iyi ifade etmenizi sağlayacaktır. Bunu önemseyerek tasarım yapıyoruz</h3>
        <p>200 TL</p> <hr> <br> <br>

        <strong>Damat Traşı</strong> <hr>
        <h3>Hayatınızın en özel gününde, düğününüze gelecek misafirlerinizin önüne sizi ifade edebilecek bir saçla çıkmanın önemini vurguluyoruz.</h3>
        <p>150 TL</p> <hr> <br> <br> -->


        
           
        </div>
      </div>
      <!-- <div class="ikisütun">

        
        <div class="sağ">

        

            <strong>Saç Tasarımı</strong> <hr>
        <h3>Mesleğiniz, giyim kuşamınız ve toplumdaki statünüzü göz önünde bulundurarak sadece size özel kafa ve yüz şeklinize göre Anatomik Saç ve Sakal kesimi yapmaktayız.</h3> 
        <P>150 TL</P><hr>  <br>  <br>
        
        <strong>Saç Düzleştirme</strong> <hr>
        <h3>Mesleğiniz, giyim kuşamınız ve toplumdaki statünüzü göz önünde bulundurarak sadece size özel kafa ve yüz şeklinize göre Anatomik Saç ve Sakal kesimi yapmaktayız.</h3>
        <p>100 TL</p> <hr> <br> <br>

        <strong>Kaş Tasarımı</strong> <hr>
        <h3>Kaşlarınızın bakımlı ve güzel olması bakışlarınızı daha iyi ifade etmenizi sağlayacaktır. Bunu önemseyerek tasarım yapıyoruz</h3>
        <p>200 TL</p> <hr> <br> <br>

        <strong>Pedikür</strong> <hr>
        <h3>Vücudumuzun tüm yükünü çeken ayaklar her zaman doğru bakımı hak etmektedir. Ayak ve tırnak bakımınızı önemseyip gerekli bakımları özenle yapıyoruz.</h3>
        <p>150 TL</p> <hr> <br> <br>
            
        
      </div>

        <div class="sol">
          
        
      </div>
    </div> -->

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

</div>
</template>

<script>
import axios from 'axios';

export default {
    data(){
        return{
            hizmetAdı:'',
            detay:'',
            fiyat: '',
            services: [],
            İletişimNo: '',
            İletişimMail: '',
            adres: '',
            iletişims: []

        }
    },

    created(){
        this.fetchServices();
        this.fetchiletisim();
    },
    methods:{
        async fetchServices(){
            try{
                const response = await axios.get('https://localhost:7134/api/Hizmet/All')
                this.services = response.data.data
            } 
            catch (error) {
                console.error('Hizmetler getirilirken bir hata oluştu:', error);
        }
            
        },

        async fetchiletisim() {
      try {
        const response = await axios.get('https://localhost:7134/api/İletişim/All')
        this.iletişims = response.data.data
      } catch (error) {
        console.error('İletişimler getirilirken bir hata oluştu:', error);
      }
    }
    }



}
</script>

<style scoped>

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


strong{
    font-size: 40px;
  
}
.container-fluid p{
  margin-top: 50px;
}

.content h1{
    color: #fff;
   
    text-align: left;
}
.left{
    color: black;
}

.two-columns {
  display: flex;
}

.left-column, .right-column {
  flex: 1;
  padding: 20px;
}
.right-column h1{
  text-align: center;
  color: black;
  margin-top: 50px;
  
}
.right-column{
  font-size: 25px;
  color:  black;
  margin-top: 100px;
}
.left-column{
background-image: url('../assets/MEN.jpg'); 
  background-size: cover;
  background-position: center;
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  font-family: Arial, sans-serif;
  color: #fff;

}
.background-container {
  background-image: url('@/assets/fotobackground1.jpg'); 
  background-size: cover;
  background-position: center;
  height: 50vh;
  display: flex;
  justify-content: center;
  align-items: center;
  font-family: Arial, sans-serif;
  color: #fff;
}



.sol{
    color: black;
}

.ikisütun {
  display: flex;
}

.sol, .sağ {
  flex: 1;
  padding: 20px;
}
.sağ h1{
  text-align: center;
  color: black;
  margin-top: 50px;
  
}
.sağ{
  font-size: 25px;
  color:  black;
}
.sol{
background-image: url('../assets/WOMAN.jpg'); 
  background-size: cover;
  background-position: center;
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  font-family: Arial, sans-serif;
  color: #fff;

}



</style>