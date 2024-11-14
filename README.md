# TraversalCore Project

**TraversalCore**, modern web uygulamalarında sıkça karşılaşılan bir dizi işlevi başarıyla yerine getiren güçlü ve esnek bir yazılım altyapısıdır. Bu proje, kullanıcı yönetimi, veri işleme, gerçek zamanlı etkileşim ve veritabanı entegrasyonu gibi önemli fonksiyonları içinde barındırarak, geliştiricilere kapsamlı bir çözüm sunmaktadır. **TraversalCore**, her seviyede kullanıcıya hitap eden fonksiyonlarla desteklenen, geliştiricilerin işini kolaylaştıran bir açık kaynak yazılım projesidir.

## Proje Özeti

TraversalCore, kurumsal yazılım çözümleri, kişisel uygulamalar ve hatta küçük ölçekli projeler için ideal bir altyapı sunan, kapsamlı bir uygulamadır. Proje, şifre yenileme, PDF/Excel dosya oluşturma, istatistik toplama, yorum ve mesajlaşma, dil değiştirme gibi birçok kullanışlı özelliği entegre etmektedir. Ayrıca **CQRS** (Command Query Responsibility Segregation) mimarisi ve **SignalR** gibi modern teknolojiler kullanılarak geliştirilmiştir.

Projenin içeriğinde bulunan başlıca özellikler, farklı işlevsel alanlarda yüksek verimlilik ve esneklik sunar. Kullanıcılar için şifre sıfırlama, mail gönderme, yorum yapma gibi özelliklerin yanı sıra, geliştiricilerin işini kolaylaştıracak veri işlemleri, istatistiksel analizler ve dinamik dosya oluşturma işlemleri de mevcuttur.

## Projede Kullanılan Teknolojiler ve Araçlar

TraversalCore projesi, modern yazılım geliştirme paradigmasını ve en güncel teknolojileri kullanarak geliştirilmiştir. Kullanılan başlıca araçlar ve teknolojiler şunlardır:

- **Entity Framework**: ORM (Object-Relational Mapping) teknolojisi ile veritabanı işlemleri yapılır. Bu, veri yönetimi ve sorgulama işlemlerini kolaylaştırır.
- **MS SQL Server** ve **PostgreSQL**: Projede veritabanı olarak MS SQL Server ve PostgreSQL kullanılmaktadır. Bu sayede, veri yönetimi konusunda esneklik ve performans sağlanır.
- **API**: RESTful API’ler kullanılarak dış uygulamalarla entegrasyon sağlanır. Uygulama, API aracılığıyla veriye erişim sunar.
- **SignalR**: Gerçek zamanlı veri iletişimi ve etkileşim için SignalR teknolojisi kullanılmıştır. Bu, anlık mesajlaşma ve veri iletimi gibi işlevsellikleri mümkün kılar.
- **Identity**: ASP.NET Core Identity kullanılarak güvenli bir kullanıcı kimlik doğrulama ve yetkilendirme altyapısı sağlanmıştır.
- **CQRS**: Command Query Responsibility Segregation (CQRS) mimarisi, veri yazma ve okuma işlemlerini ayırarak uygulamanın verimliliğini ve ölçeklenebilirliğini artırır.
- **PDF ve Excel Dosya Oluşturma**: Kullanıcılar için dinamik olarak PDF ve Excel dosyaları oluşturulabilir, bu da kullanıcı deneyimini artıran bir özellik sunar.

## Özellikler

TraversalCore, güçlü bir arka uç altyapısı ve kullanıcı dostu işlevsellikleriyle dikkat çekiyor. Projeye entegre edilmiş bazı başlıca özellikler:

### 1. **PDF Oluşturma**
   - Kullanıcılar, verilerini bir PDF dosyasına dönüştürebilir. Bu özellik, özellikle raporlar ve dokümantasyon oluşturmak için çok kullanışlıdır.
   - Kullanıcıların verilerini kolayca dışa aktarmalarına olanak tanır.

### 2. **Excel Dosyası Oluşturma**
   - Kullanıcılar, verilerini Excel formatında dışa aktarabilirler. Bu, özellikle büyük veri setleri ile çalışan kullanıcılar için kullanışlıdır.
   - Excel dosyalarında grafikler, tablolar ve dinamik veriler ile çalışmak mümkündür.

### 3. **Şifre Yenileme**
   - Kullanıcıların güvenli bir şekilde şifrelerini sıfırlayabilmesi için güçlü bir şifre sıfırlama mekanizması sağlanır.
   - E-posta doğrulama ve güvenlik soruları gibi yöntemlerle şifre sıfırlama işlemleri yapılabilir.

### 4. **İstatistikler**
   - Kullanıcılar, platforma dair çeşitli istatistikleri görüntüleyebilir. Bu, uygulamanın kullanımını izleme ve analiz etme açısından önemlidir.
   - Grafikler, tablolar ve diğer görselleştirme araçları ile kullanıcı etkileşimini daha iyi anlayabilirsiniz.

### 5. **Yorum Yapma ve Mesaj Gönderme**
   - Kullanıcılar arasında etkileşimi artıran yorum ve mesajlaşma özellikleri sunulur.
   - Gerçek zamanlı mesajlaşma SignalR kullanılarak yapılır, böylece kullanıcılar anında geri bildirim alabilirler.

### 6. **Mail Gönderme**
   - Kullanıcılar, sistem üzerinden e-posta gönderebilir. Bu özellik, kullanıcı bildirimleri ve raporlar gibi amaçlar için kullanılır.
   - Mail gönderimi için SMTP protokolü kullanılarak güvenli ve hızlı bir sistem geliştirilmiştir.

### 7. **Dil Değiştirme**
   - Çok dilli destek sunulur, böylece kullanıcılar arayüz dilini istedikleri gibi değiştirebilirler.
   - Küresel uygulamalar için ideal bir özellik sunar.

### 8. **CQRS (Command Query Responsibility Segregation)**
   - Veritabanı işlemleri üzerinde yüksek verimlilik sağlamak amacıyla CQRS kullanılmıştır.
   - Komutlar ve sorgular ayrı işlenir, bu da uygulamanın performansını artırır ve veri tutarlılığını sağlar.

### 9. **Area Yönetimi**
   - Proje modüler yapıya sahiptir. Her bir alan (Area) farklı bir işlevi yerine getirir, bu sayede uygulamanın yönetimi kolaylaştırılır.

## Kurulum ve Kullanım

### Gereksinimler

- **.NET 6.0** veya üzeri
- **MS SQL Server** veya **PostgreSQL** veritabanı
- **Visual Studio** veya tercihinize göre başka bir IDE

### Adımlar

1. **Projeyi Klonlayın**
   GitHub reposunu bilgisayarınıza klonlamak için aşağıdaki komutu kullanın:
   ```bash
   git clone [https://github.com/Abdulkerimarsln/TraversalCoreProje]
