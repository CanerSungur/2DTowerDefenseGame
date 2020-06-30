# 2DTowerDefenseGame
Game project for ODTU

#####################

Blueprint Scripts

#####################

1.EnemyBlueprint Script

      Bulunduğu Yer; Taslak olarak baz alınan script olduğudan, MonoBehaviour'a inherit değildir. Haliyle hiçbir objeye bağlı değildir.
      Amacı; Wave oluştururken içine gireceğimiz düşmanların bilgilerinden bir şablon oluşturmak.
- Hiçbir objeye bağlanmadığı için Inspector'dan erişerek data girilebilmesi için scriptin en başına [System.Serializable] eklenmiştir. Enemy'nin şablon halinde datasını tutmaktadır.
- enemyName ve enemyPrefab değişkenleri bulunmaktadır.
- Fonksiyon bulunmamaktadır.
      
2.TowerBlueprint Script

      Bulunduğu Yer; Taslak olarak baz alınan script olduğudan, MonoBehaviour'a inherit değildir. Haliyle hiçbir objeye bağlı değildir.
      Amacı; Build edilecek kulelerin genel bilgilerinden bir şablon oluşturmak.
- Hiçbir objeye bağlanmadığı için Inspector'dan erişerek data girilebilmesi için scriptin en başına [System.Serializable] eklenmiştir. Tower'ın şablon halinde datasını tutmaktadır.
- Fonksiyonlar;
      
      1.GetCostToBuild(int _costBoost); Parametre alacağı kule inşa ücretini düşüren özelliği ekleyerek kulenin inşası için gerekli değeri verecek.
      2.GetCostForLevel2(); 1 numaradaki fonksiyonu içinde çalıştırarak bu değerin belirli yüzde fazlasını return edecek.
      3.GetCostForLevel3();1 numaradaki fonksiyonu içinde çalıştırarak bu değerin belirli yüzde fazlasını return edecek.
      4.GetSellValueForLevel1(); 1 numaralı fonksiyondaki değerin yüzde 50'sini return edecek.
      5.GetSellValueForLevel2(); 2 numaralı fonksiyondaki değerin yüzde 50'sini return edecek.
      6.GetSellValueForLevel3(); 3 numaralı fonksiyondaki değerin yüzde 50'sini return edecek.

3.Wave
      
      Bulunduğu Yer; Taslak olarak baz alınan script olduğudan, MonoBehaviour'a inherit değildir. Haliyle hiçbir objeye bağlı değildir.
      Amacı; Spawn edilecek dalgaların(wave) içeriğini belirleyecek boss ve düşman arrayi tutarak wavelerin altyapısını oluşturmak.
- Hiçbir objeye bağlanmadığı için Inspector'dan erişerek data girilebilmesi için scriptin en başına [System.Serializable] eklenmiştir. Oluşturulacak Wave'lerin içeriğinde bulunacak değişkenleri ve gerekli fonksiyonlarını tutmaktadır.
- EnemyBlueprint type'ında boss ve düşman arrayleri tanımlanmıştır. Düşman adedini ve çıkış hızını belirten değişkenler de tanımlanmıştır. 
- Fonksiyonlar;
      
      1.GetRandomEnemyCount(); Kullanıcının bulunduğu Round'a göre random düşman sayısı aralığı değeri return eder.
      2.GetRandomEnemyIndex(); Toplamda oyunda bosslar hariç 6 düşman bulunmaktadır. Bu nedenle 1 ile 6 arasında random bir sayı return eder.

#####################

Build Mechanic Scripts

#####################

1.BuildManager Script

      Bulunduğu Yer; Hiyerarşideki boş GamaManager objesi.
      Amacı; Kule seçmek, seçilen kuleyi return etmek, kule inşa edilecek Node'ları seçmek ve seçimi iptal etmek.
- Her yerden kolayca erişilebilip değer tutsun diye static yapildi. Baska yerlerden erişilebilsin diye kendi içinde scripti bir 'instance' isimli değişkene atayip bunu diğer scriptlerde çağırarak BuildManager'dan rahatça işlem yapabilecegiz.
- Fonksiyonlar;
      
      1.SelectNode(Node node); Parametre girilen Node'u seçer. Bu fonksiyon Node'un OnClick fonksiyonunda kullanılacak.
      2.DeselectNode(); Zaten seçili olan Node'a bir kez daha tıklandığında seçimi iptal eder.
      3.SelectTowerToBuild(TowerBlueprint tower); Parametre girilen kuleyi inşa etmek üzere seçer. Bu fonksiyon Shop'ta kule seçiminde çağrılacak.
      4.GetTowerToBuild(); İnşa etmek üzere seçilen kuleyi return eder. Bu fonksiyon Node'da kule inşa edilirken çağrılacak.
      5.Awake(); Bu scriptin bir instance ını oluşturur.

2.Node Script

      Bulunduğu Yer; Haritadaki tüm inşa noktaları yani Node'lar.
      Amacı; UI'da seçilen kuleyi üstüne tıklandığında aynı noktada inşa etmek. Kuleleri upgrade etmek veya satmak.
- BuildManager ile iletişime geçebilmesi için BuildManager instance'ı oluşturuluyor. Üstüne geldiğinde renk değiştirebilmesi için Renderer componenti kullanılarak gerekli değişkenler kuruluyor. Upgrade olup olmadığını tutmak için bool değerler oluşturuluyor.
- Fonksiyonlar;
      
      1.Start(); Renderer componentını oluşturmak, başlangıç rengini atamak ve BuildManager instance ını oluşturmak.
      2.GetBuildPosition(); Bulunduğu pozisyonu return eder. Bu fonksiyon BuildTower fonksiyonunda kullanılacak.
      3.OnMouseDown(); Mouse tıklandığı zaman gerekli işlemler yapılacak. Seçili değilse seçmek, Gold yetiyor mu bakmak, Seçili tower varsa BuildTower'ı çalıştırmak.
      4.BuildTower(TowerBlueprint blueprint); Parametre aldığı blueprintten, Node'un bulunduğu pozisyonda bir kule inşa eder. Gold olup olmadığını kontrol eder.
      5.UpgradeTower(); Kule hiç upgrade edilmemişse 2. seviyeye, bir kez upgrade edilmişse 3. seviyeye çıkartır. Eski towerı yok edip yenisini instantiate eder.
      6.SellTower(); Mevcut kuleyi yok edip yerine Node instantiate eder. Gerekli goldu geri verir.
      7.OnMouseEnter(); Mouse objenin üstüne geldiğinde gerekli renk değişikliği sağlar.
      8.OnMouseExit(); Mouse objenin üstünden çıktığında gerekli renk değişikliği sağlar.
      
3.Shop Script

      Bulunduğu Yer; Hiyerarşideki Shop isimli Canvas.
      Amacı; UI buttonlari ilişkilendirip, buildManager'daki fonksiyonları kullanarak inşa edilecek kulenin seçilmesini sağlamak.
- BuildManager ile iletişime geçebilmesi için BuildManager instance'ı oluşturuluyor. UI'da bulunan kulelerden birisine tıklandığında bu kuleyi inşa edilecek kule olarak seçmek.
- Fonksiyonlar;
      
      1.Start(); BuildManager instance ı oluşturmak.
      2.SelectArrowTower(); BuildManager'daki SelectTowerToBuild'e Arrow Tower'ın blueprintini sokarak inşa edilecek kuleyi seçmek.
      3.SelectStoneTower(); BuildManager'daki SelectTowerToBuild'e Stone Tower'ın blueprintini sokarak inşa edilecek kuleyi seçmek.
      4.SelectMagicTower(); BuildManager'daki SelectTowerToBuild'e Magic Tower'ın blueprintini sokarak inşa edilecek kuleyi seçmek.

#####################

Player Mechanic Scripts

#####################

1.LevelUp Script

      Bulunduğu Yer; Hiyerarşideki boş GamaManager objesi.
      Amacı; Kullanıcının experience puanlarını kontrol edip gerekli puana erişince level atlamasını sağlamak.
- Fonksiyonlar;
      
      1.Update(); Sürekli olarak kontrol sağlamak için Exp fonksiyonunu burada çalıştırdık.
      2.RankUp(); Kullanıcının levelini ve attribute puanını arttırır. Mevcut experience puanını sıfırlayarak yeni seviye için gerekli puanı hesaplar.
      3.Exp(); Oyuncunun experience puanı, gerekli experience puanına erişirse RankUp fonksiyonunu çalıştıracak. Bu fonksiyon da Update fonksiyonunda çağrılıp sürekli kontrol sağlanacak.

2.PlayerStats Script

      Bulunduğu Yer; Hiyerarşideki boş GamaManager objesi.
      Amacı; Kullanıcının oyunu açınca datasını load etmek, oyunu kapatınca save etmek, istediğinde silmesini sağlamak. Kullanıcının seviye, experience miktarı, attribute puanları, verdiği stat puanları, altın ve round sayısı gibi bilgilerini tutmak. Attribute puanlarını kullanmasını sağlamak.
- Save/Load/Delete işlemlerini yapabilmek için oluşturduğumuz PlayerData'yı çağırıp, bunlarla ilgili işlemleri en başta yaptık. Daha sonra kullanıcı bilgilerini tutacağımız değişkenleri static bir şekilde tanımladık. Kullanıcının kazandığı puanları harcamasını sağlayacak fonksiyonları buraya yazdık.
- Fonksiyonlar;
      
      1.OnEnable(); Oyuna başladığında önceki dataları load ederek başlamasını sağlamak.
      2.OnDisable(); Oyundan çıktığımızda en sonki dataları kaydetmek.
      3.DeleteProgress(); Tüm oyuncu bilgilerini tamamen silmek. 
      4.Start(); Altın, round sayısı gibi static olan değerlerin gerekli atamalarını yapmak.
      5.UseAttributePoints(); Puan varsa bunu bir azaltmak, yoksa hata vermek. Bu fonksiyonu aşağıdaki fonksiyonlarda çağıracağız.
      6.AddDecreaseTowerCostPerk(); UseAttributePoints fonksiyonunu çağırıp eğer başarılı ise gerekli stat pointi harcayarak o özelliğin puanını arttırır. Daha sonra UI buttona eklenmesi için başka yerde çağrılacak.
      7.AddIncreaseFireRatePerk(); UseAttributePoints fonksiyonunu çağırıp eğer başarılı ise gerekli stat pointi harcayarak o özelliğin puanını arttırır. Daha sonra UI buttona eklenmesi için başka yerde çağrılacak.
      8.AddIncreaseProjectileDamagePerk(); UseAttributePoints fonksiyonunu çağırıp eğer başarılı ise gerekli stat pointi harcayarak o özelliğin puanını arttırır. Daha sonra UI buttona eklenmesi için başka yerde çağrılacak.

#####################

Menu Scripts

#####################

1.GameOver Script

      Bulunduğu Yer; Hiyerarşideki GameOver Canvas.
      Amacı; Oyun sonlandığında aktif olup oyunu bir kez daha açmak ya da çıkmak.
- Ekran geçişleri için SceneFader objesi eklendi.
- Fonksiyonlar;
      
      1.Retry(); Aktif sahneyi tekrar load eder.
      2.Menu(); Menü sahnesini load eder.

2.InfoMenu Script

      Bulunduğu Yer; Hiyerarşideki boş GameManager objesi.
      Amacı; UI'da info kutusuna basıldığında oyun oynanışıyla ilgili bilgi vermek ve belirli saniyelerle en alttaki info bölümünde random bilgi vermek.
- Info penceresinde ve alttaki info boxta gösterilmesi için iki ayrı liste oluşturuldu. Bu UI'larla ilgil textlerin değişkenleri de oluşturuldu.
- Fonksiyonlar;
      
      1.Start(); İki ayrı listenin elemanlarını eklemek.
      2.Update(); Geri sayım yaparak ShowRandomInfo coroutine fonksiyonunu çalıştırmak.
      3.IEnumerator ShowRandomInfo(); Atanan UI'a belirli aralıklarla listeden random bir stringi return etmek.
      4.Toggle(); Oyunu durdurup tekrar başlatmak.
      5.ShowNextText(); UI'daki ok işaretine atanacaktır. Ekrana basılmış listenin sonraki elemanına geçer.
      6.ShowPreviousText(); UI'daki ok işaretine atanacaktır. Ekrana basılmış listenin bir önceki elemanına geçer.

3.Menu Script

      Bulunduğu Yer; MainMenu sahnesindeki boş MainMenu objesi.
      Amacı; Oyunu başlatmak ya da oyundan çıkmak.
- Ekran geçişleri için SceneFader objesi eklendi.
- Fonksiyonlar;
      
      1.Play(); Oyunu açar.
      2.Quit(); Oyundan çıkar.

4.PauseMenu Script

      Bulunduğu Yer; Hiyerarşideki PauseMenu Canvas.
      Amacı; Ekrandaki tuşuna, ESC tuşuna ya da P tuşuna basıldığında oyunu durdurmak. Oyuncu isterse Menü'ye dönmek ya da oyunu baştan başlatmak.
- Ekran geçişleri için SceneFader objesi eklendi.
- Fonksiyonlar;
      
      1.Update(); Sürekli olarak kontrol ederek ESC ya da P tuşuna basıldığında Toggle fonksiyonunu çalıştırmak.
      2.Toggle(); Oyunu durdurup tekrar başlatmak.
      3.Retry(); Aktif sahneyi tekrar load eder.
      4.Menu(); Menü sahnesini load eder.

5.RoundsSurvived Script

      Bulunduğu Yer; Hiyerarşideki GameOver Canvas içerisindeki RoundsSurvived UI'ı.
      Amacı; Oyun sonlandığında ekrana gelecek olan UI'a animasyon şeklinde hayatta kalınan Round sayısını vermek.
- Fonksiyonlar;
      
      1.OnEnable(); Bu kod aktif olduğunda çalışacak olan AnimateText'i içine girdik.
      2.IEnumerator AnimateText(); 0'dan başlayarak hayatta kalınan rounda kadar animasyon şeklinde tek tek yazdıracak.

6.SceneFader Script

      Bulunduğu Yer; SceneFader game objesi.
      Amacı; Sahne geçişlerinde ekranın yavaşça kararıp tekrar yavaşça aydınlanmasını sağlamak.
- Siyah bir panel bulunan boş bir oyun objesini animasyon mantığı kullanarak yavaşça görünür ve yavaşça görünmez yapmak suretiyle sahne geçişi yapmak amaçlanır. Bunun için bir Img değişkeni ve AnimationCurve değişkeni tanımlandı. Bu sayede giderek hızlanacak şekilde animasyon yapabileceğiz.
- Fonksiyonlar;
      
      1.Start(); Başlancıta FadeIn courotine ini çalıştırmak.
      2.IEnumerator FadeIn(); Siyah resmi giderek alphasını düşürerek görünmez yapmak.
      3.IEnumerator FadeOut(string scene); Görünmeyen siyah resmin alphasını açarak giderek görünür yapmak. Daha sonra parametre girilen sahneyi açmak.
      4.FadeTo(string scene); Parametre girilen sahneye doğru FadeOut fonksiyonunu coroutine haline kullanarak geçişi yapmak.
    
7.StatChanger Script

      Bulunduğu Yer; MainMenu sahnesindeki boş MainMenu objesi.
      Amacı; Diğer objelerde tanımlanan stat puanlarını UI'a gömülen buttonlar ile çalıştırmak.
- Fonksiyonlarını kullanabilmek için PlayerStats objesi oluşturuldu. Gerekli Text alanları oluşturuldu ve atamaları yapıldı.
- Fonksiyonlar;
      
      1.Update(); Stat değişikliklerini sürekli kontrol ederek gerekli text alanlarını gerekli değerlerle doldurmak.
      2.ChangeCost(); PlayerStats'daki AddDecreaseTowerCostPerk fonksiyonunu çalıştırır.
      2.ChangeFireRate(); PlayerStats'daki AddIncreaseFireRatePerk fonksiyonunu çalıştırır.
      2.ChangeProjectileDamage(); PlayerStats'daki AddIncreaseProjectileDamagePerk fonksiyonunu çalıştırır.

#####################

Load/Save/Delete Scripts

#####################

1.PlayerData Script

      Bulunduğu Yer; MonoBehaviour ile ilişkili değildir. Hiçbir objeye bağlı değildir.
      Amacı; Oyunda kaydedilmesi gereken değişkenlerin tanımlarını tutmak.
- Kaydedilmesini istediğimiz tüm değişkenlerimiz ile aynı type ve isimde get; set; kullanarak birer değişken oluşturuldu.
- Fonksiyon yok.
     
2.PlayerPersistence Script

      Bulunduğu Yer; MonoBehaviour ile ilişkili değildir. Hiçbir objeye bağlı değildir.
      Amacı; PlayerData objesini kullanarak gerekli dosya konumlarını oluşturup oralara bilgileri kaydetmek, oralardan bilgi çekmek veya silmek.
- Fonksiyonlar;
      
      1.LoadData(); İstenilen değişkenleri istenilen konumlara ekleyerek oluşturulan PlayerData değşikenine bu değerleri atmak ve değer atılan bu datayı return etmek.
      2.SaveData(PlayerStats playerStats); Mevcut PlayerStat değişkenlerinin bilgilerini gerekli yerlere kaydetmek.
      3.DeleteAll(); Kayıtlı bilgilerin tümünü silmek ve sildikten sonra değişkenlerin başlangıç değerlerini tanımlamak.
 
#####################

Spawn Mechanic Scripts

#####################

1.WaveSpawner Script

      Bulunduğu Yer; Hiyerarşideki boş GameManager objesi.
      Amacı; Başka scriptlerden edinilen random sayıları alarak random sayıda ve çeşitlilikte sonsuz düşmanlar spawn etmek.
- Blueprintte oluşturduğumuz Wave typeında bir dalga oluşurup bunu inspectordan düzenliyoruz. Alınan random değerler kullanılarak haritadaki hayattaki düşman sayısı sıfırlandıkça çalışacak şekilde düşman çıkarıyoruz.
- Fonksiyonlar;

      1.Update(); Sürekli bir şekilde kontrol sağlayarak, hayatta düşman yoksa SpawnWave fonksiyonunu çalıştırıp sayacı saniyede bir azaltmak.
      2.IEnumarator SpawnWave(); WaypointDecider'dan yol belirleyip diğer scriptten aldığı random değerleri kullanarak düşman dalgası oluşturmak. Belirli roundlara geldiğinde ilgili bossları spawn etmek. 
      3.SpawnEnemy(EnemyBlueprint enemyBlueprint); Parametre aldığı düşman şablonunda bir düşman instantiate etmek. Bu fonksiyon SpawnEnemy fonksiyonu içinde çağrılacak.
      
2.WaypointDecider Script

      Bulunduğu Yer; Hiyerarşideki boş GameManager objesi.
      Amacı; Haritada bulunan 3 oldan random bir tanesini seçmek. Belirli roundlarda kapalı olan yolları aktif etmek.
- Üç adet waypoint objesi tanımlandı. WaveSpawner objesi oluşturuldu. Random bir yola karar verilip o waypoint aktif diğerleri pasife geçirilip spawn pointi aktif olan waypoint yapacağız.
- Fonksiyonlar;
      
      1.DecideWaypoint(); 1 ile 3 arasında random bir sayı üreterek o waypointi aktif eder ve yeni spawnPoint'i o nokta yapar. 5.Round'a gelindiğinde ikinci yolun, 10.Round'a gelindiğinde ise üçüncü yolun açılmasını sağlar.
      
3.Waypoint Script

      Bulunduğu Yer; Boş waypoint objelerinin parentı olan boş Waypoints objesi.
      Amacı; Çocuğu olan tüm waypoint objelerini sırası ile bir arraye atmak suretiyle düşman için gidilecek bir rota belirlemek.
- Fonksiyonlar;
      
      1.Awake(); Tüm childların konumunu tutacak Transform arrayine childların hepsinin bilgilerini atmak.
      
#####################

UI Scripts

#####################

1.NodeUI Script

      Bulunduğu Yer; NodeUI objesi.
      Amacı; Kuleyi upgrade edecek ve satacak fonksiyonları çağırmak. Gold miktarlarını göstermek.
- Kulelerin üstüne tıklanınca gözüküp tekrar tıklanınca yok olan bir objedir. Node'a erişim için Node objesi oluşturulmuştur. Bu sayede Node'u hedef belirleyip nerede çıkıp çıkmayacağını halledebileceğiz.
- Fonksiyonlar;

      1.SetTarget(Node _target); Parametre aldığı Node'u hedef gösterip ilgili Gold değerlerini göstermek.
      2.Hide(); UI'ı pasif yapmak.
      3.Upgrade(); Node'daki UpgradeTower fonksiyonunu çağırmak. BuildManager'dan DeselectNode fonksiyonunu çağırarak bu Node'u deselect etmek.
      4.Sell(); Node'daki SellTower fonksiyonunu çağırmak. BuildManager'dan DeselectNode fonksiyonunu çağırarak bu Node'u deselect etmek.

2.ArrowTowerCostUI Script
3.AttributePointsUI
4.GoldUI
5.LevelsUI
6.LivesUI
7.MagicTowerCostUI
8.RoundsUI
9.StoneTowerCostUI

      Bulukları Yerler; İlgili text UI objeleri
      Amaçları; İlgili değerleri ilgili Text konumlarında göstermek. 
- Bu scriptlerin içerikleri aynıdır. Konumları hiyerarşideki ilgili UI Text alanlarıdır. Inspectordan da atamaları yapıldıktan sonra bilgiler bu alanlara bastırılmıştır.
- Fonksiyonlar;
      
      1.Update(); Sürekli kontrol sağlayarak gerekli bilgilerin ilgili Text alanına işlenmesini sağlamak.
      
#####################

Other Scripts

#####################

1.CameraController Script

      Bulunduğu Yer; Kamera.
      Amacı; Klavye ya da mouse ile kameranın hareket etmesi ve belirli bir alanda sınırlandırılması.
- Pan hızı, kenar kalınlığı, min-max x ve y değerlerinin atamaları yapıldı.
- Fonksiyonlar;

      1.Update(); Anlık takip edilmesi gerektiğinden update içine yazıldı. Min ve max değerlerin belirli değerlerle sınırlı tutulması. Kamera hareket ettirme değerlerinin de bu değerler uygulanması.
 
2.Enemy Script

      Bulunduğu Yer; Düşman Prefableri.
      Amacı; Düşmanlarla ilgili tüm bilgileri tutmak. Damage almak, ölmek, yavaşlamak, waypoint doğrultusunda ilerlemek ve yolun sonuna gelince yok olmak, kullanıcıya hasar vermek.
- Health, experience puanı, gold değeri, ölüp ölmediğini tutan bool değeri, hedefini belirten Transform değerlerinin tanımlamaları yapıldı.
- Fonksiyonlar;

      1.Start(); İlk hedefin Waypoints[0] olarak belirlenmesi, başlancıç değişken atamalarının yapılması.
      2.TakeDamage(float damageAmount); Parametre kadar hp'ye zarar vermek. Hp barın seviyesini ayarlamak. Eğer düşmanın canı 0 ya da daha az olmuş ise Die fonksyionunu çağırmak.
      3.Slow(float pct); Parametre kadar düşmanın hızını belirli bir oranda yavaşlatmak.
      4.Die(); Bool değeri true ya çekmek. Kullanıcının goldunu arttırmak, haritadaki düşman sayısını azaltmak, experience puanını arttırmak ve düşman objesini yok etmek.
      5.Update(); Sürekli olarak düşmanı kendi hızına göre diğer waypoint elemanına doğru ilerletmek. Bunun için GetNextWaypoint fonksiyonunu çağıracak.
      6.GetNextWaypoint(); Eğer waypoint arrayindeki son elemana da gelmişse EndPath fonksiyonunu çalıştırır. Yoksa indexi arttırarak arraydeki sonraki elemana doğru gidilmesi sağlanır.
      7.EndPath(); Kullanıcının canına zarar vermek, düşmanı yok etmek.
      
3.GameManager Script

      Bulunduğu Yer; Hiyerarşideki boş GameManager objesi.
      Amacı; Oyun bitişi, başlangıcı gibi hangi ekran geleceği ve genelde oyuna ne olacağına karar vermek.
- Her yerde değişmeden tutulsun ve erişilebilsin diye static GameIsOver bool yaptık. Gerekli ekran UI'ları da burada tanımlandı.
- Fonksiyonlar;
      
      1.Start(); Oyun başlangıcında GameIsOver'ı false yapmak.
      2.Update(); Oyunun bitip bitmediğini sürekli kontrol edip canımız sıfırlanınca GameIsOver'ı true yapmak.
      3.EndGame(); GameIsOver'ı true yapmak ve GameOver UI'ını aktif etmek.

4.Projectile Script

      Bulunduğu Yer; Oyundaki projectile prefablerinin hepsi.
      Amacı; Projectile objelerin hedefi bulması, vurması, damage vermesi, yavaşlatması.
- Hedef belirlemek amacıyla konum tutan target isimli Transform yapıldı. Projectile'ın hızı, damage, alan damage vuruyorsa ilgili değerler, slow yapıyorsa ilgili değerler tanımlandı.
- Fonksiyonlar;
      
      1.SeekTarget(Transform target); Girilen parametredeki konum değerini bizim hedefimiz olarak atamak.
      2.Update(); Hedefi sürekli takip etmek için buraya yazıldı. Projectile konumunu hedefin konumuna eşitleyip objeyi oraya fırlatmak.
      3.HitTarget(); Hedefe damage vermek ve projectile objesini yok etmek.
      4.Damage(Transform enemy); Girilen parametredeki konumdaki düşmana damage vermek. Bunun için fonksiyon içinde bir düşman objesi oluşturup oraya eriştik ve düşmanın TakeDamage fonksiyonu ile düşmana damage vermiş olduk.
      5.OnDrawGizmoSelected(); Bu sadece sahne ekranında objenin girilen alan damage i etki alanını göstermeye yarıyor.

5.Tower Script

      Bulunduğu Yer; Tüm kule prefableri.
      Amacı; Kulelerin bilgilerini tutmak, atış noktasının hedefe doğru kitlenmesini sağlamak, ateş etmek.
- Hedef konumu için target Transform oluşturduk. Kulenin etki alanı, atacağı projectile obje değişkeni, ateşi buradan edeceğimiz için ateş hızı, hedefi belirtmek için 'Enemy' tagi tanımı, ateş edilecek noktanın ve hedefe kitlenirken hareket edecek partToRotate objelerinin tanımları yapıldı.
- Fonksiyonlar;
            
            1.Start(); InvokeRepeating ile oyun açılınca belirli saniye aralıklarında sürekli çalışan UpdateTarget fonksiyonunu çalıştırmak.
            2.UpdateTarget(); Düşmanlardan oluşan bir GameObject arrayi yaparak, bu düşmanlar içerisinde kuleye mesafesi en kısa olanı bularak targeti o olarak belirler. Sınırımız dışındaki targetlere kitlenmez.
            3.Update(); Her saniye target olup olmadığını kontrol etmek için buraya yazıldı. Düşman olup olmadığını takip etmek ve eğer varsa bu düşmana LockOnTarget ile kitlenmesini ve Shoot ile ateş etmesini sağlamak. 
            4.LockOnTarget(); Hedef ile kule arasındaki mesafeyi hesaplayarak partToRotate'e gerekli rotasyonu yaptırmak.
            5.Shoot(); Bir projectile objesi oluşturmak, bu objeyi belirlenen hızda ve mesafede hedefe doğru yollamak. Hedefi bulunca da projectile ı yok etmek. Bunu Projectile'daki SeekTarget fonksiyonunu burada cağırarak yaptık.
            6.OnDrawGizmosSelected(); Tower'ın Range'ini görebilmek için, belirlenmiş range mesafesinde çizgi çizer.
