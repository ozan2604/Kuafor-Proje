<template>
  <div class="rezervasyonView">
    <h1>Rezervasyon İşlemleri</h1>
    <div class="container">
      <div class="form-group">
        <label for="selectedDateTime">Tarih ve Saat Seçiniz:</label>
        <input type="datetime-local" id="selectedDateTime" v-model="selectedDateTime" @input="validateDateTime" :min="minDateTime">
        <p v-if="selectedDateTime">Seçilen Tarih ve Saat: {{ selectedDateTime }}</p>
      </div>
      <div class="form-group">
        <label for="selectKuaför">Berber Seçiniz:</label>
        <select id="selectKuaför" v-model="selectedKuaför" class="form-control" @change="changeBerber">
          <option disabled value="">Lütfen bir berber seçin</option>
          <option v-for="kuaför in barbers" :key="kuaför.id" :value="kuaför.id">{{ kuaför.kuaförName }}</option>
        </select>
      </div>
      <div class="form-group">
        <label for="selectHizmet">Hizmet Seçiniz:</label>
        <select id="selectHizmet" v-model="selectedHizmet" class="form-control">
          <option disabled value="">Lütfen bir hizmet seçin</option>
          <option v-for="hizmet in services" :key="hizmet.id">{{ hizmet.hizmetAdı }}</option>
        </select>
      </div>
      <div class="form-group">
        <label for="selectKullanıcı">Kullanıcı Adı Giriniz:</label>
        <input type="text" id="selectKullanıcı" v-model="selectedKullanıcı" required>
      </div>
      <button @click="makeReservation" class="btn btn-primary">Rezervasyon Yap</button>
      <p v-if="errorMessage" class="error-message">{{ errorMessage }}</p>
      <p v-if="successMessage" class="success-message">{{ successMessage }}</p>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      selectedDateTime: '',
      selectedKuaför: '',
      selectedHizmet: '',
      selectedKullanıcı: '',
      errorMessage: '',
      successMessage: '',
      barbers: [],
      services: [],
      minDateTime: '',
      rezervations: [],
    };
  },
  created() {
    this.fetchBarbers();
    this.fetchServices();
    this.fetchRezervasyon();
    const now = new Date();
    this.minDateTime = now.toISOString().slice(0, 16);
  },
  methods: {
    async fetchBarbers() {
      try {
        const response = await axios.get('https://localhost:7134/api/Kuaför/All');
        this.barbers = response.data.data;
      } catch (error) {
        console.error('Berberler getirilirken bir hata oluştu:', error);
      }
    },
    async fetchRezervasyon() {
      try {
        const response = await axios.get('https://localhost:7134/api/Rezervasyon/All');
        this.rezervations = response.data.data;
      } catch (error) {
        console.error('Kullanıcı adı getirilirken bir hata oluştu:', error);
      }
    },
    async fetchServices() {
      try {
        const response = await axios.get('https://localhost:7134/api/Hizmet/All');
        this.services = response.data.data;
      } catch (error) {
        console.error('Hizmetler getirilirken bir hata oluştu:', error);
      }
    },
    async makeReservation() {
      const reservationData = {
        rezervasyonTarih: this.selectedDateTime,
        kuaför_Id: this.selectedKuaför,
        hizmet_Id: this.selectedHizmet,
        musteriKullaniciAdi: this.selectedKullanıcı,
      };
      try {
        const response = await axios.post('https://localhost:7134/api/Rezervasyon/Save', reservationData);
        console.log('Rezervasyon yapıldı:', response.data);
        this.successMessage = 'Rezervasyon başarıyla yapıldı!';
        this.errorMessage = '';
      } catch (error) {
        console.error('Rezervasyon yapılırken bir hata oluştu:', error);
        this.successMessage = '';
        this.errorMessage = 'Rezervasyon yapılırken bir hata oluştu. Lütfen başka bir saat veya kuaför seçiniz.';
      }
    },
    changeBerber(e) {
      console.log('Seçilen berber:', this.selectedKuaför);
    },
    validateDateTime(event) {
      const selectedDateTime = new Date(event.target.value);
      const now = new Date();
      if (selectedDateTime < now) {
        this.selectedDateTime = '';
        alert('Geçmiş bir tarih ve saat seçemezsiniz.');
      }
    }
  }
};
</script>

<style scoped>
h1 {
  background-color: black;
  color: #fff;
  text-align: center;
  padding: 20px;
  border-radius: 5px;
}

.container {
  max-width: 600px;
  margin: 50px auto;
  padding: 20px;
  background-color: #f8f9fa;
  border-radius: 5px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

.form-group {
  margin-bottom: 20px;
}

label {
  display: block;
  font-weight: bold;
  margin-bottom: 5px;
}

input[type="datetime-local"],
select,
input[type="text"] {
  width: 100%;
  padding: 10px;
  font-size: 16px;
  border: 1px solid #ced4da;
  border-radius: 4px;
  box-sizing: border-box;
}

button {
  display: block;
  width: 100%;
  background-color: black;
  color: #fff;
  border: none;
  padding: 10px;
  font-size: 16px;
  cursor: pointer;
  border-radius: 4px;
}

button:hover {
  background-color: #0056b3;
}

.error-message {
  color: red;
  margin-top: 10px;
}

.success-message {
  color: green;
  margin-top: 10px;
}
</style>
