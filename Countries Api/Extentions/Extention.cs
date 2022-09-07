namespace Countries_Api.Extentions
{
    public static class Extention
    {
        public static bool isImage(this IFormFile file)
        {
            return file.ContentType.Contains("image");
        }
        public static bool isLower4mb(this IFormFile file)
        {
            return file.Length / 1024 > 8192;
        }
        public static async Task<string> savefileAsync(this IFormFile file, string folder)
        {
            string filename = Guid.NewGuid().ToString() + file.FileName;
            string path = Path.Combine(folder, filename);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return filename;

        }
    }
}
