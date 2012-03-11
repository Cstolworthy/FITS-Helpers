// Copyright 2008 Louis DeJardin - http://whereslou.com
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using IronRubyViews.Models;

namespace IronRubyViews.Models
{
    public class ProductRepository
    {
        public IList<Product> GetProducts()
        {
            var appData = (string) AppDomain.CurrentDomain.GetData("DataDirectory");
            var ser = new DataContractSerializer(typeof (List<Product>));
            using (var stream = new FileStream(Path.Combine(appData, "Products.xml"), FileMode.Open, FileAccess.Read))
            {
                return (IList<Product>) ser.ReadObject(stream);
            }
        }

        public Product FindProduct(int id)
        {
            return GetProducts().FirstOrDefault(p => p.Id == id);
        }
    }
}