
# Apartman Yönetim Sistemi

Bu projenin ne yaptığı ve kimin için olduğu hakkında kısa bir açıklama

## Yapılanlar
- [x] Identity
  - [x] Token oluşturma
  - [x] Kullanıcı/yönetici ekle
  - [x] Rol Ekleme


- [x] Apartments
  - [x] Tüm daire ve apartmanları listele
  - [x] Apartment ve daire bilgileri ekle
  - [x] UserId'ye göre konum bilgileri
  - [x] ApartmentID'ye göre kullanıcı bilgileri
  - [x] Kullanıcı bilgilerini daire için düzenleme


- [x] Payments
    - [x] Ödemeleri listele
    - [x] Ödemeleri ID'ye göre listeleme
    - [x] Ödemeleri güncelle
    - [x] Ödemeleri sil
    - [x] Ödeme ekleme


- [ ] Borçlar
    - [ ] Borçları listele
    - [ ] Borçluları listele - apartman - kullanıcı
    - [ ] Borç güncelle
    - [ ] Borç öde
  

- [ ] Aidatlar
    - [ ] Aidatları listele - düzenli ve geç ödeyenler
    - [ ] Aidat ekle - indirimli aidat durumu 
    - [ ] Aidat güncelle



## DB Yapısı

 ### Kurgusal DB Yapısı -  [drawsql](https://drawsql.app/teams/ezgi/diagrams/ezgi)

![DB Yapısı](./README_ASSETS/diagramIdea.png) 

Yapısı ile kurguya başlasamda, daha sonra bu yapıyı aşağıdaki gibi değiştirdim. 

 ### Yeni DB Yapısı

![DB Yapısı](./README_ASSETS/diagramFinal.jpg)

    

## API Kullanımı

Postman veya benzeri bir araç ile aşağıdaki endpointler kullanılabilir.

collection dosyası: [Export v2.1 --> ApartmentManagementAPI.postman_collection.json](./README_ASSETS/ApartmentManagementAPI.postman_collection.json)

collection dosyası: [Export v2.0 --> ApartmentManagementAPI.postman_collection.json](./README_ASSETS/ApartmentManagementAPI.postman_collection2.0.json)

collection paylaşım linki: [Apartman Yönetim Sistemi](https://dark-star-90151.postman.co/workspace/Management-System~959e5f18-86a1-4dd7-8a68-ac89bc58b88c/collection/30918894-9edd228e-14d3-46e6-9623-f746fc999782?action=share&creator=30918894)

### Identity


#### Create User

```http
  POST /api/identity/CreateUser
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `tcNo` | `string` | **Gerekli**. |
| `phoneNumber` | `string` | **Gerekli**.  |
| `password` | `string` | **Gerekli**. Identity API password validation vardır. |

#### Öğeyi getir

```http
  GET /api/items/${id}
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Gerekli**. Çağrılacak öğenin anahtar değeri |
