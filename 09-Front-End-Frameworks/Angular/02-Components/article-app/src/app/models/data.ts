import { data } from './seed';
import {Article} from './article.model';

export class ArticleData {
  getData(): Article[] {

    const articles: Article[] = [];

    for (let i = 0; i < data.length; i++ ) {
      articles[i] = new Article(data[i].title, data[i].description, data[i].author, data[i].imageURL);
    }

    return articles;
  }
}