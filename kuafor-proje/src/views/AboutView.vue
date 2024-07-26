<template>
  <div class="about">
    <div class="container-fluid" id="baslık">
      <div>
        <h1>{{ baslık }}</h1>
      </div>
    </div>

    <div class="two-columns">
      <div class="left-column">
        <img class="foto" src="../assets/kadir-alkan.jpeg" alt="resim" width="600" height="750">
        <div class="a">
          <h3>SAÇ SAKAL ERKEĞİN MAKYAJIDIR</h3>
        </div>
        <p class="b">Kadir Alkan</p>
      </div>
      <div class="right-column" id="paragraf">
        <p>1935 yılında dedesi ile başlayıp, babasıyla devam eden kuaförlük serüvenine 12 yaşından itibaren dahil olmuş, aynı zamanda eğitim hayatına devam etmiştir.</p>
        <p>Sonucunda Kocaeli Üniversitesi Bilgisayar Programcılığı ve Anadolu Üniversitesi İşletme Fakültelerini bitirmiştir. Eğitim hayatında bir dönüm noktası belirleyip dede mesleği kuaförlük üzerine rotasını çizip bu işi de eğitimli, donanımlı bir şekilde yapmayı öngörmüştür.</p>
        <p>Bu düşünce akabinde, diksiyon eğitimi ve beden dili, yurt içi ve yurt dışı bir çok akademi ve eğitmenden teknik kesim, renklendirme ve ürün eğitimlerini tamamlamıştır.</p>
        <p>2015 te İtalya’da gerçekleşen organizasyonda Türk Ekibi üyesi olarak, ülkemize dünya ikinciliğini getirdi.</p>
        <p>Kendini, meslektaşlarının eğitimine katkıda bulunma konusunda sorumlu hissetmiş, aldığı teknik eğitimleri geleneksel berberlik ile harmanlayarak 1000’lerce meslektaşına patentini aldığı Anatomik Saç Kesimi, salon işletmeciliği, müşteri ilişkileri, sosyal medya konularını da eğitim programına katarak, bilgi birikimini onlara aktarmaya devam etmektedir.</p>
        <p>Her şehire bir Kadir Alkan projesi kapsamında İstanbul’da Etiler genel merkez, Göktürk, Sultanahmet, Bahçelievler, Beylikdüzü, Kurtköy, İstanbul dışı Ankara, İzmir merkez ve Alaçatı, Bursa, Antalya, Kocaeli, Gaziantep, Denizli, Sivas, Bolu, Samsun, Trabzon, Ordu ve Türkmenistan Aşgabat’ta salonları olup, Cumhuriyetin 100. yılında yurt dışı vizyonuyla Miami, Dubai, Londra, Amsterdam, Berlin, Bakü salon anlaşmalarıyla ülkemizde ve yurt dışında franchise salonlar açmaya devam etmektedir.</p>
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
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      baslık: "Kadir Alkan Kimdir?",
      İletişimNo: '',
      İletişimMail: '',
      adres: '',
      iletişims: []
    }
  },
  created() {
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
    }
  }
}
</script>

<style scoped>
body {
  font-size: 18px;
}

.container-fluid p {
  margin-top: 50px;
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

#baslık {
  background-color: black;
  color: #fff;
  height: 100px;
  text-align: center;
  padding: 20px;
}

#paragraf {
  margin-top: 60px;
}

.b {
  text-align: center;
}

.a {
  color: black;
  margin-top: 30px;
  text-align: center;
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

.right-column {
  font-size: 25px;
  color: black;
}

.foto {
  display: block;
  margin: 0 auto;
}

</style>
